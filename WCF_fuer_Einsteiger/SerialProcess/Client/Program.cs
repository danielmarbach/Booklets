namespace Client
{
    using System;

    using Client.WCFCalculatorServiceReference;

    class Program
    {
        static void Main(string[] args)
        {
            WCFCalculatorServiceClient service = new WCFCalculatorServiceClient();

            int value1 = 3;
            int value2 = 6;

            // usual program flow
            int result1 = service.Summarize1(value1, value2);
            CalculationResult result2 = service.Summarize2(value1, value2);
            Console.WriteLine("<<<<<\n--- serial process ---");
            Console.WriteLine("\n --OperationContract--\n Sum of " + value1 + " and " + value2 + " is " + result1);
            Console.WriteLine("\n --DataContract with ExtensibleDataObject--\n Sum of " + value1 + " and " + value2 + " of operation '" + result2.Operation + "' is " + result2.Result);

            // MessageContract
            string secondHeader;
            string firstMessageBody;
            string secondMessageBody;
            string thirdMessageBody;
            service.GetServiceState(out secondHeader, out firstMessageBody, out secondMessageBody, out thirdMessageBody);
            Console.WriteLine("\n --MessageContract--\n GetServiceStates by MessageContract: " + 
                "\n First MessageHeader: "  +
                "\n First MessageBodyMember: " + firstMessageBody +
                "\n Second MessageHeader: " + secondHeader +
                "\n Second MessageBodyMember: " + secondMessageBody +
                "\n Third MessageBodyMember: " + thirdMessageBody);

            // oneWay
            service.SetParameters(value1, value2);
            Console.WriteLine("\n<<<<<\n--- OneWay with DataContract ---");
            Console.WriteLine(" Parameter were set.");
            var test = service.GetParameters();
            Console.WriteLine(" GetParameters: " + " parameter a: " + test.a + " parameter b: " + test.b + " .");
            Console.Read();
        }
    }
}
