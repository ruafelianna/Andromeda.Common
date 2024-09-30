using Andromeda.Concurrent.Enums;
using Andromeda.Concurrent.Exceptions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Andromeda.Concurrent
{
    public class RepeatedTask<TResult> : ReactiveObject
    {
        public RepeatedTask(Func<CancellationToken, Task<TResult>> unit)
        {
            _unit = unit;

            _sync = new();

            State = TaskState.Stopped;

            StateObservable = this
                .WhenAnyValue(o => o.State);

            CanStartObservable = StateObservable
                .Select(state => state == TaskState.Stopped);

            CanStartObservable.ToPropertyEx(this, o => o.CanStart);

            CanStopObservable = StateObservable
                .Select(state => state == TaskState.Started);

            CanStopObservable.ToPropertyEx(this, o => o.CanStop);

            RepeatsObservable = this.WhenAnyValue(o => o.Repeats);

            RetriesObservable = this.WhenAnyValue(o => o.Retries);

            AttemptsObservable = this.WhenAnyValue(o => o.Attempts);
        }

        public IObservable<bool> CanStartObservable { get; }

        public IObservable<bool> CanStopObservable { get; }

        public IObservable<TaskState> StateObservable { get; }

        public IObservable<uint> RepeatsObservable { get; }

        public IObservable<uint> RetriesObservable { get; }

        public IObservable<uint> AttemptsObservable { get; }

        public IObservable<TResult> Start(
            RepeatedTaskOptions options = default
        )
        {
            lock (_sync)
            {
                if (!CanStart)
                {
                    throw new TaskAlreadyStartedException();
                }

                State = TaskState.StartRequested;
            }

            Repeats = 0;
            Retries = 0;
            Attempts = 0;

            _tokenSource = new();

            var observable = Observable.Create<TResult>(
                async observer => {
                    Exception? exception = null;

                    while (true)
                    {
                        try
                        {
                            try
                            {
                                if (_tokenSource.IsCancellationRequested)
                                {
                                    break;
                                }

                                if (
                                    options.MaxAttempts is not null
                                    && Attempts >= options.MaxAttempts
                                )
                                {
                                    break;
                                }

                                if (
                                    options.MaxRepeats is not null
                                    && Repeats >= options.MaxRepeats
                                )
                                {
                                    break;
                                }

                                Attempts++;

                                var result = await _unit(_tokenSource.Token);

                                observer.OnNext(result);

                                Repeats++;

                                if (options.ResetRetriesAfterSuccess)
                                {
                                    Retries = 0;
                                }

                                if (options.TimeBetweenRepeats is not null)
                                {
                                    await Task.Delay(
                                        options.TimeBetweenRepeats.Value,
                                        _tokenSource.Token
                                    );
                                }
                            }
                            catch (Exception ex)
                            {
                                if (options.ResetRepeatsAfterFail)
                                {
                                    Repeats = 0;
                                }

                                if (
                                    options.MaxRetries is not null
                                    && Retries >= options.MaxRetries
                                )
                                {
                                    exception = ex;
                                    break;
                                }

                                Retries++;

                                if (options.TimeBetweenRetries is not null)
                                {
                                    await Task.Delay(
                                        options.TimeBetweenRetries.Value,
                                        _tokenSource.Token
                                    );
                                }
                            }
                        }
                        catch (TaskCanceledException)
                        {
                        }
                    }

                    _tokenSource.Dispose();
                    _tokenSource = null;

                    lock (_sync)
                    {
                        State = TaskState.Stopped;
                    }

                    if (exception is null)
                    {
                        observer.OnCompleted();
                    }
                    else
                    {
                        observer.OnError(exception);
                    }
                }
            );

            State = TaskState.Started;

            return observable;
        }

        public void RequestStop()
        {
            lock (_sync)
            {
                if (!CanStop)
                {
                    throw new TaskAlreadyStoppedException();
                }

                State = TaskState.StopRequested;
            }

            _tokenSource!.Cancel();
        }

        private readonly object _sync;

        private CancellationTokenSource? _tokenSource;

        private readonly Func<CancellationToken, Task<TResult>> _unit;

        [Reactive]
        private TaskState State { get; set; }

        [ObservableAsProperty]
        private bool CanStart { get; }

        [ObservableAsProperty]
        private bool CanStop { get; }

        [Reactive]
        private uint Repeats { get; set; }

        [Reactive]
        private uint Retries { get; set; }

        [Reactive]
        private uint Attempts { get; set; }
    }
}
