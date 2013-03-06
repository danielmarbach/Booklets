namespace DuplexClient
{
    using System;
    using System.ServiceModel;
    using DuplexClient.DuplexContractService;

    public class Program
    {
        static void Main(string[] args)
        {
            ClientCallbackHandler clientCallbackHandler = new ClientCallbackHandler();
            clientCallbackHandler.SummarizeStart(clientCallbackHandler);
            Console.ReadLine();
        }
    }

    public class ClientCallbackHandler : IDuplexContractServiceCallback
    {
        public DuplexContractServiceClient dsClient = null;

        public InstanceContext site = null;

        public void SummarizeStart(ClientCallbackHandler clientHandler)
        {
            site = new InstanceContext(clientHandler);
            dsClient = new DuplexContractServiceClient(site);
            dsClient.Summarize(5, 7);
        }

        public void NotifyMessage(int reply)
        {
            Console.WriteLine("Result: " + reply.ToString());
        }
    }
}

