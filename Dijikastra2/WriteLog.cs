using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijikastra2
{
    class WriteLog
    {
        public void Log(string LogMsg, TextWriter W)
        {
            W.WriteLine("Log for Dijkastra Algorithm");
            W.WriteLine("{0}, {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            W.WriteLine(":{0}", LogMsg);
        }
    }
}
