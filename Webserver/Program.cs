using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Webserver.HttpServer;

namespace Webserver
{
    public class Program
    {

        public static void Main(string[] args)
        {
            HTTPListener httpListener = new HTTPListener();
            httpListener.RunTime();
        }
    }
}