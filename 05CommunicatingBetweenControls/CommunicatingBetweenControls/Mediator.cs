using CommunicatingBetweenControls.Model;
using System;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        // Singleton pattern implementation
        private static readonly Mediator _instance = new Mediator();

        private Mediator() { }

        public static Mediator GetInstance()
        {
            return _instance;
        }

        // Mediator pattern implementation
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(Object sender, Job job)
        {
            JobChanged?.Invoke(sender, new JobChangedEventArgs { Job = job });
        }
    }
}
