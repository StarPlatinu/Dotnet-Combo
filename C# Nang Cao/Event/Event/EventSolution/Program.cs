using System;
using System.Security.Cryptography.X509Certificates;

namespace Event
{
    //public delegate void EventHandler(object sender?, EventArgs e);
    //public delegate void EventHandler<TEventArgs>(object sender?, TEventArgs e);
    public class MyEventArgs : EventArgs
    {
        private string data;

        public string Data
        {
            get { return data; }
        }
        public MyEventArgs(string data) {
            this.data = data;
        }

    }

    public class classA
    {
        public event EventHandler event_news;

        public void Send()
        {
            event_news?.Invoke(this, new MyEventArgs("Have a new message ..."));
        }
    }


    //public class classB
    //{
    //    public void Sub(classA p)
    //    {
    //        p.event_news += ReciverFormPublisher;
    //    }

    //    private void ReciverFormPublisher(object sender, MyEventArgs e)
    //    {
    //        Console.WriteLine("classB: "+e.Data);
    //    }
    //}

 
}