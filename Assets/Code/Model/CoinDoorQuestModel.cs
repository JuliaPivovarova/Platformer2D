using Code.Interfaces;
using UnityEngine;

namespace Code.Model
{
    public class CoinDoorQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";
        private bool _isKeyToDoor = false;

        public void HasKey()
        {
            _isKeyToDoor = true;
        }
        public bool TryComplete(GameObject activator)
        {
            bool doorCouldBeOpened = activator.CompareTag(TargetTag) && _isKeyToDoor;
            return doorCouldBeOpened;
        }
    }
}