using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Valenia.Verity.Listeners
{
    public class Listener : IDisposable
    {
        private readonly int _port;
        private readonly OnListen _handler;
        public VeritySDK.Handler.Handlers Handlers { get; set; }

        private HttpListener _listener;
        private static readonly ILogger _log = Log.ForContext<Listener>();

        public Listener(int port, OnListen handler)
        {
            _port = port;
            _handler = handler;
            Handlers = new VeritySDK.Handler.Handlers();
        }

        public delegate void OnListen(string message);

        public void Listen()
        {
            var prefix = $"http://*:{_port}/";
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefix);
            try
            {
                _listener.Start();
            }
            catch (HttpListenerException ex)
            {
                _log.Error(ex, "Error during the startup of Verity Listener"); 
                throw;
            }

            Task.Run(ProcessRequest);
        }

        private void ProcessRequest()
        {
            while (_listener.IsListening)
            {
                var context = _listener.GetContext();

                var data = new StreamReader(context.Request.InputStream).ReadToEnd();

                _handler(data);

                var b = Encoding.UTF8.GetBytes("Success");
                context.Response.StatusCode = 200;
                context.Response.KeepAlive = false;
                context.Response.ContentLength64 = b.Length;

                var output = context.Response.OutputStream;
                output.Write(b, 0, b.Length);
                context.Response.Close();
            }
        }

        public void Dispose()
        {
            _listener.Stop();
            _listener.Close();
        }
    }
}
