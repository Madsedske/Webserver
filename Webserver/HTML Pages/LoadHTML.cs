using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webserver
{
    public class LoadHTML
    {
        public static int pageView = 0;

        public static string pageData1 =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>The best HttpListener in the world!</title>" +
        "  </head>" +
        "  <body>" +
        "    <p>Sikke en fin hjemmeside. PageView: {0}</p>" +
        "    <form method=\"post\" action=\"changePage\">" +
        "      <input type=\"submit\" value=\"Change the page\" {1}>" +
        "    </form>" +
        "  </body>" +
        "</html>";

        public static string pageData2 =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>The best HttpListener in the world!</title>" +
        "  </head>" +
        "  <body>" +
        "   <h1> God overskrift </h1>" +
        "    <p>Nu er hjemmesiden meget pænere. PageView: {0}</p>" +
        "    <form method=\"post\" action=\"shutdown\">" +
        "      <input type=\"submit\" value=\"Shutdown\" {1}>" +
        "    </form>" +
        "  </body>" +
        "</html>";
    }
}
