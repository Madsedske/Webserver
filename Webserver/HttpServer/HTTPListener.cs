using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Webserver.HttpServer
{
    public class HTTPListener
    {
        public static string url = "http://localhost:8080/";
        public static HttpListener listener;
        private static int requestCount;
        private static bool runServer = true;

        public void RunTime()
        {
            listener = new HttpListener();
            Thread listenTask = new Thread(HttpListenerService);

            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening on {0}", url);

            listenTask.Start();
            //listenTask.GetAwaiter().GetResult();

            if (runServer == false)
            {
                listener.Close();
            }
        }


        public void HttpListenerService()
        {
            while (runServer)
            {
                HttpListenerContext ctx = listener.GetContext();

                HttpListenerRequest req = ctx.Request;

                Console.WriteLine("Remote end point: {0}", req.RemoteEndPoint.ToString());
                Console.WriteLine("Protocol version: {0}", req.ProtocolVersion);
                Console.WriteLine("Is authenticated: {0}", req.IsAuthenticated);
                Console.WriteLine("Is secure: {0}", req.IsSecureConnection);
                Console.WriteLine("Request #: {0}", ++requestCount + "\r\n" +
                    req.Url.ToString() + "\r\n" +
                    req.HttpMethod + "\r\n" +
                    req.UserHostName + "\r\n" +
                    req.UserAgent + "\r\n");


                switch (req.HttpMethod)
                {
                    case "GET":
                        HttpListenerResponse resp = ctx.Response;

                        string disableSubmit = !runServer ? "disabled" : "";
                        byte[] data = Encoding.UTF8.GetBytes(String.Format(LoadHTML.pageData1, LoadHTML.pageView, disableSubmit));
                        resp.StatusCode = (int)HttpStatusCode.OK;
                        resp.ContentType = "text/html";
                        resp.ContentEncoding = Encoding.UTF8;
                        resp.ContentLength64 = data.LongLength;

                        resp.OutputStream.Write(data, 0, data.Length);
                        resp.Close();
                        break;

                    case "POST":
                        if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
                        {
                            runServer = false;
                        }

                        if (req.Url.AbsolutePath == "/changePage")
                        {
                            GetRequest();
                        }
                        break;
                }
            }
        }

        public void GetRequest()
        {
            HttpListenerContext ctx = listener.GetContext();
            HttpListenerResponse resp = ctx.Response;

            LoadHTML.pageView++;

            string disableSubmit = !runServer ? "disabled" : "";
            byte[] data = Encoding.UTF8.GetBytes(String.Format(LoadHTML.pageData2, LoadHTML.pageView, disableSubmit));
            resp.StatusCode = (int)HttpStatusCode.OK;
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;

            resp.OutputStream.Write(data, 0, data.Length);
            resp.Close();
        }
    }
}
