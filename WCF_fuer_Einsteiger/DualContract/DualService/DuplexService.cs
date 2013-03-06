namespace DuplexContract
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DuplexContractService : IDuplexContractService
    {
        // contains the Client Channel references
        List<Answer> operationDictionary = null;

        public DuplexContractService()
        {
            operationDictionary = new List<Answer>();
            Thread thread = new Thread(delegate() { SendResultToClient(); });
            thread.Start();
        }

        public void Summarize(int a, int b)
        {
            operationDictionary.Add(
                new Answer { CalculationResult = a + b, OperationContext = OperationContext.Current });
        }

        private void SendResultToClient()
        {
            while (true)
            {
                if (operationDictionary.Count > 0)
                {
                    foreach (var operation in operationDictionary)
                    {
                        IClientCallback proxy = operation.OperationContext.GetCallbackChannel<IClientCallback>();
                        proxy.NotifyMessage(operation.CalculationResult);
                    }
                }
            }
        }
    }
    public struct Answer
    {
        public int CalculationResult;
        public OperationContext OperationContext;
    }
}

