namespace WCFService
{
    public class WCFCalculatorService : IWCFCalculatorService
    {
        private static int ValueA { get; set; }

        private static int ValueB { get; set; }

        public int Summarize1(int a, int b)
        {
            return a + b;
        }

        public CalculationResult Summarize2(int a, int b)
        {
            return new CalculationResult() { Result = a + b, Operation = "summarize2" };
        }

        public void SetParameters(int a, int b)
        {
            ValueA = a;
            ValueB = b;
        }

        public Parameters GetParameters()
        {
            return new Parameters { a = ValueA, b = ValueB };
        }

        public Message GetServiceState()
        {
            return new Message
                {
                    FirstOperationBody = "firstBody",
                    FirstOperationHeader = "firstHeader",
                    SecondOperationBody = "secondBody",
                    SecondOperationHeader = "secondHeader",
                    ThirdOperationBody = "thirdBody"
                };
        }
    }
}