using System;

namespace DelegatesAndEvents
{
    public class Worker
    {
        public EventHandler WorkCompleted;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;

        public void Dowork(int hours, WorkType workType)
        {
            for (var i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(500);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed;
            if (del != null) del(this, new WorkPerformedEventArgs(hours, workType));
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted;
            del?.Invoke(this, EventArgs.Empty);
        }
    }
}