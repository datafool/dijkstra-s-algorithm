using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Dijikastra2
{
    public class Calculation
    {
        private List<Node> node;        
        private List<Edge> edge;        
        private Dictionary<string, double> dist;
        private Dictionary<string, bool> check;
        private Dictionary<string,string> previous;
        // Constructor to initialize  Nodes and Edges of the grah
        public Calculation(List<Node> _node, List<Edge> _edge)
        {
            node = _node;
            edge = _edge;
            initialize();
        }

        // Method to initialize other values of the Calculation1 class
        private void initialize()
        {
            dist = new Dictionary<string, double>();
            check = new Dictionary<string, bool>();
            previous = new Dictionary<string,string>();
            foreach (Node n in node)
            {
                previous.Add(n.Name,null);
                dist.Add(n.Name,double.MaxValue);
                check.Add(n.Name, false);
            }
        }
        // Method to travers the graph to find shortest path
            public double graph_traversal(string start, string target, string log)
            {
                
                int i = 0;
                dist[start] = 0;
                previous[start] = start;
                // Coding everthing in using block, so that we can write everything in log 
                using (StreamWriter w = File.AppendText(log))
                {
                    w.WriteLine("Starting Node is {0} and target node is {1}", start, target);
                    foreach (Node n in node)
                    {
                        i++;
                        Node u = GetMinDistance();
                        check[u.Name] = true;
                        w.WriteLine("Chosen node is {0}", u.Name);
                        //Finding neighbour of above node, so that we can update the distance                    
                        List<Node> neighbourNode = new List<Node>();
                        neighbourNode = GetNeighbour(u);

                        foreach (Node inNeighbourNode in neighbourNode)
                        {
                            double dist1 = dist[u.Name] + GetDistanceBetweenNode(u, inNeighbourNode);
                            w.WriteLine("Neighbour node of {0} is {1} and it's distance from starting node is {2}", u.Name, inNeighbourNode.Name, dist1);
                            w.WriteLine("=============");
                            if (dist1 != 0 && dist1 < dist[inNeighbourNode.Name] && check[inNeighbourNode.Name] == false)
                            {
                                dist[inNeighbourNode.Name] = dist1;
                                previous[inNeighbourNode.Name] = u.Name;

                            }
                        }
                    }
                }
                return dist[target];
                    
            }
            
            public List<string> GetPath(string start, string target)
            {
                var path = new List<string>();
                path.Insert(0,target);
                int i = 1;
                while (previous[target] != start)
                {
                    path.Insert(i++, previous[target]);
                    target = previous[target];
                }
                path.Insert(i, previous[start]);
                return path;    
            }

            // Method to Calculate the distance between any two given nodes
            private double GetDistanceBetweenNode(Node u, Node item)
            {                
                foreach (Edge e in edge)
                {
                    if (e.Origin == u.Name && e.Destination == item.Name)
                    {
                        return e.Distance;
                    }
                }
                return double.MaxValue;
            }

           // Methods to find the Neighbour of any given Node
            private List<Node> GetNeighbour(Node U)
            {
                List<Node> v = new List<Node>();
                foreach (Edge e in edge)
                {
                    if (U.Name == e.Origin)
                    {
                        Node x = new Node();
                        x.Name = e.Destination;
                        v.Add(x);
                    }   
                }
                return v;
            }

            // Method to fnid the next Minimum distance and hence the node using which we will traverse the node
            private Node GetMinDistance()
            {
                double distance = double.MaxValue;
                Node u = new Node();
                foreach (Node  n in node)
                {
                    if ( check[n.Name] == false  && dist[n.Name] < distance)
                    {
                        u = n;
                        distance = dist[n.Name];
                    }
                }
                return u;
            }
            
        
    }
}
