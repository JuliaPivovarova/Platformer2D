using UnityEngine;

namespace Code.Interfaces
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}