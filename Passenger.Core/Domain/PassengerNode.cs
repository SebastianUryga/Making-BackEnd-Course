using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        public Node Node { get; protected set; }
        public Passenger Passenger { get; protected set; }

        protected PassengerNode( )
        {

        }
        public PassengerNode(Passenger passsenger, Node node)
        {
            Passenger = passsenger;
            Node = node;
        }
        public static PassengerNode Create(Passenger passsenger, Node node) =>
            new PassengerNode(passsenger, node);
    }
}
