using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    public delegate int BizRulesDeleate(int x, int y);

    internal class Program
    {

        private static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer {City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer {City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer {City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer {City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4}
            };

            var pxhCustomers = customers
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);
            foreach (var cust in pxhCustomers)
            {
                Console.WriteLine($"{cust.LastName}, {cust.FirstName} from {cust.City }");
            }

            BizRulesDeleate addDel = (x, y) => x + y;
            BizRulesDeleate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, addDel);
            data.Process(2, 3, multiplyDel);

            Action<int, int> myAction = (x, y) => Console.WriteLine("add action " + (x + y));
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine("multiply action " + (x * y));
            data.ProcessAction(2, 3, myAction);
            data.ProcessAction(2, 3, myMultiplyAction);

            Func<int, int, int> functionAddDelegate = (x, y) => x + y;
            Func<int, int, int> functionMultiplyDelegate = (x, y) => x * y;
            data.ProcessFunction(3, 2, functionAddDelegate);
            data.ProcessFunction(3, 2, functionMultiplyDelegate);

            var worker = new Worker();
            //            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformed);
            //            worker.WorkCompleted += new EventHandler(WorkCompleted);

            // delegate inference:
            //            worker.WorkPerformed += WorkPerformed;
            //            worker.WorkCompleted += WorkCompleted;

            // to remove the delegate from the handler:
            //            worker.WorkCompleted -= WorkCompleted;

            // anonymous methods:
            //            worker.WorkPerformed +=
            //                delegate (object o, WorkPerformedEventArgs e)
            //                {
            //                    Console.WriteLine($"Work Performed: {e.Hours} hour(s) of {e.WorkType}");
            //                };
            //            worker.WorkCompleted += delegate(object o, EventArgs e) { Console.WriteLine("Work completed"); };

            // lambdas
            worker.WorkPerformed += (o, e) =>
            {
                Console.WriteLine($"Work Performed: {e.Hours} hour(s) of {e.WorkType}");
                Console.WriteLine("This line just shows how you can have multiple lines of code in a lambda.");
            };
            worker.WorkCompleted += (o, e) => Console.WriteLine("Work completed");

            worker.Dowork(8, WorkType.GenerateReports);
        }

        //        private static void WorkCompleted(object o, EventArgs e)
        //        {
        //            Console.WriteLine("Work completed");
        //        }
        //
        //        private static void WorkPerformed(object o, WorkPerformedEventArgs e)
        //        {
        //            Console.WriteLine($"Work Performed: {e.Hours} hour(s) of {e.WorkType}");
        //        }
    }
}