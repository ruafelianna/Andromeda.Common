using System;

namespace Andromeda.Concurrent.Exceptions
{
    internal class TaskAlreadyStoppedException : ApplicationException
    {
        public TaskAlreadyStoppedException()
        {
        }

        public TaskAlreadyStoppedException(string? message) :
            base(message)
        {
        }

        public TaskAlreadyStoppedException(
            string? message,
            Exception? innerException
        ) : base(message, innerException)
        {
        }
    }
}
