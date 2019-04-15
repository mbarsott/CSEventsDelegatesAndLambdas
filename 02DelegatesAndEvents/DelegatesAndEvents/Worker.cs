using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
//    public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
//        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public EventHandler WorkCompleted;

        public void Dowork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i+1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
//            if (WorkPerformed != null) WorkPerformed(this, new WorkPerformedEventArgs(hours, workType));
//            var del = WorkPerformed as WorkPerformedHandler;
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null) del(this, new WorkPerformedEventArgs(hours, workType)); 
        }

        protected virtual void OnWorkCompleted()
        {
//            WorkCompleted?.Invoke(this, EventArgs.Empty);

            var del = WorkCompleted as EventHandler;
            del?.Invoke(this, EventArgs.Empty);
        }
    }
}
