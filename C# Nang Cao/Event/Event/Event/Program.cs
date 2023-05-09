using System;

namespace Event_
{
    public class Publisher
    {
        public delegate void NotifyNews(object data);

        public NotifyNews event_news;

        public void Send()
        {
            event_news?.Invoke("Co Tin Moi");

        }
    }

    public class SubcribleA
    {
        public void Sub(Publisher p)
        {
            p.event_news += ReciverFromPublisher;
        }

        private void ReciverFromPublisher(object data)
        {
            Console.WriteLine("Subcriber A: "+data.ToString());
        }
    }

    public class SubcribleB
    {
        public void Sub(Publisher p) {
            p.event_news = null;
            p.event_news += ReceiverFromPublisher;
        }

        private void ReceiverFromPublisher(object data)
        {
            Console.WriteLine("SubcriberB: "+data.ToString());
        }

        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            SubcribleA sa = new SubcribleA();
            SubcribleB sb = new SubcribleB();

            sa.Sub(p);
          //  sb.Sub(p);

            p.Send();
        }
    }
}