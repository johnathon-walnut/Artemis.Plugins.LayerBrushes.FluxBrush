using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Artemis.Plugins.LayerBrushes.FluxBrush
{
    internal class FluxServer
    {
        private static readonly Lazy<FluxServer> _instance = new(() => new FluxServer()); //crongleton

        public static FluxServer Instance => _instance.Value;

        private HttpListener _listener;
        private Thread? _listenerThread;
        private int _currentKelvin = 6500;
        private readonly object _temperatureLock = new();

        private int _refCount = 0;
        private readonly object _threadLock = new();

        private FluxServer()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:4077/flux/");
        }

        public void Start()
        {
            lock (_threadLock)
            {
                _refCount++;
                if (_refCount > 1)
                    return;

                _listener.Start();
                _listenerThread = new Thread(ListenLoop) { IsBackground = true };
                _listenerThread.Start();
            }
        }

        public void Stop()
        {
            lock (_threadLock)
            {
                _refCount--;
                if (_refCount > 0)
                    return;

                _listener?.Stop();
                _listenerThread?.Join();
            }
        }
        public int GetKelvin()
        {
            lock (_temperatureLock)
            {
                return _currentKelvin;
            }
        }

        private void ListenLoop()
        {
            while (_listener.IsListening)
            {
                try
                {
                    var context = _listener.GetContext();
                    var query = context.Request.QueryString;

                    if (int.TryParse(query["ct"], out int kelvin))
                    {
                        _currentKelvin = kelvin;
                    }

                    var buffer = Encoding.UTF8.GetBytes("glup");
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.Close();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
