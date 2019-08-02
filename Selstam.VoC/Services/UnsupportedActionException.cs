namespace Selstam.VoC.Services
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnsupportedActionException : Exception
    {
        public UnsupportedActionException(string vin, string action) : this($"Car with VIN {vin} has no support for action {action}.")
        { }

        public UnsupportedActionException(string message) : base(message)
        { }

        public UnsupportedActionException(string message, Exception inner) : base(message, inner)
        { }

        protected UnsupportedActionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        { }
    }
}