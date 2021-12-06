using System;

namespace Code.Interfaces
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}