using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UsingEventsDemo
{
    public delegate void BeatDelegate(object sender, HeartbeatEventArgs e);

    public class HeartbeatEventArgs : EventArgs
    {
        public HeartbeatEventArgs(int count)
            : base()
        {
            this.Count = count;
        }

        public int Count { get; private set; }
    }

    class Heartbeat
    {
        public event BeatDelegate Beat;

        bool stop = false;
        int count;

        public Heartbeat()
        {
            count = 0;
        }

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(() =>
                {
                    while (!stop)
                    {                        
                        OnBeat(this, new HeartbeatEventArgs(count));
                        count++; 
                        Thread.Sleep(3000);   
                    }
                }));
            thread.Start();
        }

        public void Stop()
        {
            stop = true;
        }

        protected virtual void OnBeat(object sender, HeartbeatEventArgs e)
        {
            if(Beat != null)
            {
                Beat(sender, e);
            }
        }
    }
}
