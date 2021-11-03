using System;

namespace Passenger.Core.Domain
{
    public class DomainException : PassengerException
    {
        protected DomainException()
        {
        }
        public DomainException(string code)
            : base(code)
        { }
        public DomainException(string massage, params object[] args)
            : base(string.Empty, massage, args)
        { }
        public DomainException(string code, string massage, params object[] args)
            : base(null, code, massage, args)
        { }
        public DomainException(Exception innerException, string massage, params object[] args)
            : base(innerException, string.Empty, massage, args)
        { }
        public DomainException(Exception innerException, string code, string massage, params object[] args)
            : base(code, string.Format(massage, args), innerException)
        {
        }
    }
}
