using System;

namespace DomainHandlerBus.EventBus
{
    public class Command : EventArgs
    {
        public bool WasSuccess { get; private set; }
        public DateTime Occurred { get; private set; }
        public string ErrorMessage { get; private set; }

        public Command()
        {
            Occurred = DateTime.Now;
        }

        public void Success()
        {
            WasSuccess = true;
        }

        public void SetErrorMessage(string errorMessage)
        {
            if (!WasSuccess)
                ErrorMessage = errorMessage;
        }
    }
}