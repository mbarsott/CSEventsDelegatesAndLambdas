using System;

namespace DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    internal class Program
    {

        private static void Main(string[] args)
        {
            var worker = new Worker();
            //            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformed);
            //            worker.WorkCompleted += new EventHandler(WorkCompleted);

            // delegate inference:
            //            worker.WorkPerformed += WorkPerformed;
            //            worker.WorkCompleted += WorkCompleted;

            // to remove the delegate from the handler:
            //            worker.WorkCompleted -= WorkCompleted;

            // anonymous methods:
            worker.WorkPerformed +=
                delegate (object o, WorkPerformedEventArgs e)
                {
                    Console.WriteLine($"Work Performed: {e.Hours} hour(s) of {e.WorkType}");
                };
            worker.WorkCompleted += delegate(object o, EventArgs e) { Console.WriteLine("Work completed"); };

            worker.Dowork(8, WorkType.GenerateReports);
        }

        private static void WorkCompleted(object o, EventArgs e)
        {
            Console.WriteLine("Work completed");
        }

        private static void WorkPerformed(object o, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Work Performed: {e.Hours} hour(s) of {e.WorkType}");
        }
    }
}