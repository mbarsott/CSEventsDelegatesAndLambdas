using System;

namespace DelegatesAndEvents
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDeleate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been processed");
        }

        public void ProcessFunction(int x, int y, Func<int, int, int> functionDelegate)
        {
            var result = functionDelegate(x, y);
            Console.WriteLine($"Function processed. Result = {result}");
        }
    }
}
