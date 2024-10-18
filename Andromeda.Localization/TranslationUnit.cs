using Andromeda.Localization.Abstractions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;

namespace Andromeda.Localization
{
    public class TranslationUnit : ReactiveObject, ITranslationUnit
    {
        public TranslationUnit(
            ITranslationProvider provider,
            string key
        )
        {
            Key = key;

            provider
                .WhenAnyValue(o => o.Culture)
                .Select(culture => provider
                    .GetTranslation(
                        this,
                        culture
                    )
                )
                .ToPropertyEx(this, o => o.Value);
        }

        public string Key { get; }

        [ObservableAsProperty]
        public string? Value { get; }
    }
}
