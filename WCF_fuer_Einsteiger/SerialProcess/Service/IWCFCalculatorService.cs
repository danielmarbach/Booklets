namespace WCFService
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface IWCFCalculatorService
    {
        // usual program flow 
        [OperationContract]
        int Summarize1(int a, int b);

        // usual program flow DataContract with ExtensibleDataObject
        [OperationContract]
        CalculationResult Summarize2(int a, int b);

        // with use of message contract
        [OperationContract]
        Message GetServiceState();

        // OneWay Contract
        [OperationContract(IsOneWay = true)]
        void SetParameters(int a, int b);

        // DataContract
        [OperationContract]
        Parameters GetParameters();
    }

    [DataContract]
    public class CalculationResult : IExtensibleDataObject
    {
        private ExtensionDataObject data;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        [DataMember]
        public int Result { get; set; }

        [DataMember]
        public string Operation { get; set; }

        [DataMember]
        public Message ResponseMessage { get; set; }
    }

    [DataContract]
    public class Parameters
    {
        [DataMember]
        public int a { get; set; }

        [DataMember]
        public int b { get; set; }
    }

    [MessageContract]
    public class Message
    {
        [MessageHeader]
        public string FirstOperationHeader { get; set; }

        [MessageBodyMember]
        public string FirstOperationBody { get; set; }

        [MessageHeader]
        public string SecondOperationHeader { get; set; }

        [MessageBodyMember]
        public string SecondOperationBody { get; set; }

        [MessageBodyMember]
        public string ThirdOperationBody { get; set; }
    }
}


