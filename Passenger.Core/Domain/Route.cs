using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public string Name { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
        public double Distance { get; protected set; }
        protected Route()
        {
            
        }

        protected Route(string name, Node startNode, Node endNode)
        {
            Name = name;
            StartNode = startNode;
            EndNode = endNode;
        }

        public static Route Create(string name, Node startNode, Node endNode, double distance) =>
            new Route(name, startNode, endNode);
    }
}
