using System;

namespace EventEmitter.Jobs
{
    public interface IJob
    {
        void Execute();
    }

    public class Job1 : IJob
    {
        public void Execute()
        {
            Console.Write(1);
        }
    }
    public class Job2 : IJob
    {
        public void Execute()
        {
            Console.Write(2);
        }
    }
}