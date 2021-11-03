using System;

namespace Passenger.Core.Domain
{
    public abstract class PassengerException : Exception
    {
        public string Code { get; }

        protected PassengerException()
        { 
        }
        public PassengerException(string code)
        {
            Code = code;
        }
        public PassengerException(string massage, params object[] args)
            : this(string.Empty, massage, args)
        { }
        public PassengerException(string code, string massage, params object[] args) 
            : this(null, code, massage, args)
        { }
        public PassengerException(Exception innerException, string massage, params object[] args)
            : this(innerException, string.Empty, massage,args)
        { }
        public PassengerException(Exception innerException,string code, string massage, params object[] args)
            : base(string.Format(massage, args),innerException)
        {
            Code = code;
        }
    }
}
