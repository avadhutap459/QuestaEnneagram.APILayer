using QuestaEnneagram.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.Service
{
    public class Logger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Look mom, i'm logging");
        }
    }
}
