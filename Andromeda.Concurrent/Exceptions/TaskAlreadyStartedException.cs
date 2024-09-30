using System;

namespace Andromeda.Concurrent.Exceptions
{
    public class TaskAlreadyStartedException : ApplicationException
    {
        public TaskAlreadyStartedException()
        {
        }

        public TaskAlreadyStartedException(string? message) :
            base(message)
        {
        }

        public TaskAlreadyStartedException(
            string? message,
            Exception? innerException
        ) : base(message, innerException)
        {
        }
    }
}
