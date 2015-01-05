using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijikastra2
{
    class Program
    {

        static void Main(string[] args)
        {
            var file = @"C:\Users\Pawan\Documents\C#Boot Camp\Graph.csv";
            var log_file = @"C:\Users\Pawan\Documents\C#Boot Camp\Graph.txt";
            using (StreamWriter w = File.AppendText(log_file))
            {

                w.WriteLine("Log for Dijkasrta");
            }
                StringBuilder sb = new StringBuilder();
                WriteLog log = new WriteLog();            
                GraphRead graph = new GraphRead();
                List<Edge> edge = graph.ReadEdge(file, log_file);
                List<Node> node = graph.ReadNode(edge);                                  
                Calculation cal = new Calculation(node, edge);
                double dist = new double();
                List<string> path = new List<string>();
                string start =  "A";
                string target = "G";
                dist = cal.graph_traversal(start, target, log_file);
                path = cal.GetPath(start, target);            
            using(StreamWriter w = File.AppendText(log_file))
	        {		 
                w.WriteLine("Shortest distance between {0} to {1} is {2} and shortest path is", start, target, dist);
                Console.WriteLine("Shortest distance between node {0} and {1} is {2} and the shortest path is", start, target, dist);
                foreach (var inPath in path)
                {                    
                    w.Write(" {0} ", inPath);
                    Console.Write("{0} ", inPath);                
                }
            }                                           
        }
    }
}
