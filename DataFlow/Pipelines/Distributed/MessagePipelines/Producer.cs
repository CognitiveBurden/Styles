using System.Messaging;

namespace MessagePipelines
{
    public class Producer
    {
        private MessageQueue channel;

        public Producer(string channel)
        {
            string channelName = string.Format(@".\private$\{0}", channel);
            EnsureQueueExists(channelName);
        }

        public void End()
        {
            var requestMessage = new Message {Body = "", Label = "MT_COMPLETE"};

            channel.Send(requestMessage);

            requestMessage.TraceMessage();
        }

        public void EnsureQueueExists(string channelName)
        {
            channel = !MessageQueue.Exists(channelName) ? MessageQueue.Create(channelName) : new MessageQueue(channelName);
        }


        public void Send(string message)
        {
            var requestMessage = new Message {Body = message, Label = "MT_SENDING"};

            channel.Send(requestMessage);

            requestMessage.TraceMessage();
        }
    }
}