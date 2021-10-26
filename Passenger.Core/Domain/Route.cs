using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }

        protected Route()
        {
            Id = Guid.NewGuid();
        }

        protected Route(Node startNode, Node endNode)
        {
            StartNode = startNode;
            EndNode = endNode;
        }

        public static Route Create(Node startNode, Node endNode) =>
            new Route(startNode, endNode);
    }
}
