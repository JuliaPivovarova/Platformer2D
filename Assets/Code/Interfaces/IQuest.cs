using System;

namespace Code.Interfaces
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Completed; 
        bool IsComplete { get; }
        void Reset();
    }
}