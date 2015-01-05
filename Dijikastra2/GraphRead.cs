using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijikastra2
{
    class GraphRead
    {
        public List<Edge> ReadEdge(string file, string log)
        {
                        
            var reader = new StreamReader(File.OpenRead(file));
            var edge = new List<Edge>();
            Console.WriteLine("Graph is --");
            Console.WriteLine("Origin Edge, Destination Edge, Edge Length");
            using (StreamWriter w = File.AppendText(log))
            {
                w.WriteLine("Graph is --");
                w.WriteLine("Origin Edge, Destination Edge, Edge Length");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    edge.Add(new Edge { Origin = values[0], Destination = values[1], Distance = Convert.ToDouble(values[2]) });
                    w.WriteLine("{0}, {1}, {2}", values[0], values[1], values[2]);
                    Console.WriteLine("{0}, {1}, {2}", values[0], values[1], values[2]);
                }
            }
            return edge;
        }
        public List<Node> ReadNode(List<Edge> edge)
        {
            var node = new List<Node>();
            
            var node1 = edge.Select(x => x.Origin).Distinct();
            var node2 = edge.Select(x => x.Destination).Distinct();
            
            node1 = node1.Concat(node2);
            node1 = node1.Distinct();                        
                        
            foreach (var n in node1)
            {
                node.Add(new Node { Name = n });

            }
            return node;
        }
        
    }
}
