using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

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
            BizRulesDeleate addDel = (x, y) => x + y;
            BizRulesDeleate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, addDel);
            data.Process(2, 3, multiplyDel);

            Action<int, int> myAction = (x, y) => Console.WriteLine("add action " + (x+y)) ;
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine("multiply action " + (x*y)) ;
            data.ProcessAction(2, 3, myAction);
            data.ProcessAction(2, 3, myMultiplyAction);

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