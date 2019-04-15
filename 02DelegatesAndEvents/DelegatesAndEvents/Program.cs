using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }


    class Program
    {
        public delegate int WorkPerformedHandler(int hours, WorkType workType);

        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

//            del1(5, WorkType.Golf);
//            del2(10, WorkType.GenerateReports);

//            DoWork(del1);

//            del1 += del2 + del3;
//            int finalHours = del1(7, WorkType.GenerateReports);
//            Console.WriteLine(finalHours);

            Worker worker = new Worker();
//            worker.WorkPerformed += new DelegatesAndEvents.WorkPerformedHandler(WorkPerformed);
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformed);
            worker.WorkCompleted += new EventHandler(WorkCompleted);
            worker.Dowork(3, WorkType.GoToMeetings);
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed1 called. {hours} hours and {workType.ToString()} workType");
            return hours + 1;
        }
        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed2 called. {hours} hours and {workType.ToString()} workType");
            return hours + 2;
        }
        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed3 called. {hours} hours and {workType.ToString()} workType");
            return hours + 3;
        }

        static void WorkCompleted(Object o, EventArgs e)
        {
            Console.WriteLine("Work completed");
        }

        static void WorkPerformed(Object o, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Work Performed: {e.Hours} hour(s) of {e.WorkType}");
        }
    }
}
