namespace DuplexContract
{
    using System.ServiceModel;

    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IDuplexContractService
    {
        [OperationContract(IsOneWay = true)]
        void Summarize(int a, int b);
    }

    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyMessage(int reply);
    }
}
