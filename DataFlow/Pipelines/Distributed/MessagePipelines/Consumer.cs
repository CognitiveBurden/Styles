using System;
using System.Messaging;
using System.Threading.Tasks;
using Topshelf;

namespace MessagePipelines
{
    public class Consumer
    {
        private readonly MessageQueue channel;
        private bool isRunning;
        protected HostControl hostControl;

        public Consumer(string inputChannelName)
        {
            //We need to identify how the message is formatted - xml is the default
            channel = new MessageQueue(string.Format(@".\private$\{0}", inputChannelName)) {Formatter = new XmlMessageFormatter(new[] {typeof (string)})};
            //We want to trace message headers such as correlation id, so we need to tell MSMQ to retrieve those
            channel.MessageReadPropertyFilter.SetAll();
            channel.ReceiveCompleted += Consume;
        }

        public void Start(HostControl hostControl)
        {
            isRunning = true;
            this.hostControl = hostControl;
            channel.BeginReceive(new TimeSpan(0, 0, 0, ConfigurationSettings.PollingTimeout));
            Console.WriteLine("Service started");
        }


        public void Pause()
        {
            isRunning = false;
            Console.WriteLine("Service paused");
        }

        public void Stop()
        {
            isRunning = false;
            channel.Close();
            Console.WriteLine("Service stopped");
        }

        protected virtual bool ProcessMessage(Message message)
        {
            message.TraceMessage();
            return true;
        }

        private void Consume(object source, ReceiveCompletedEventArgs result)
        {
            var queue = (MessageQueue) source;
            try
            {
                var message = queue.EndReceive(result.AsyncResult);
                if (message != null)
                {
                    isRunning = ProcessMessage(message);
                }
            }
            catch (MessageQueueException mqe)
            {
                Console.WriteLine("{0} {1}", mqe.Message, mqe.MessageQueueErrorCode);
                Task.Delay(500).Wait();
            }

            if (isRunning)
            {
                queue.BeginReceive(new TimeSpan(0, 0, 0, ConfigurationSettings.PollingTimeout));
            }
        }
    }
}
