using System;
using Code.Interfaces;
using Code.Model;
using Code.View;

namespace Code.Controllers
{
    public class QuestWithDoorsController: IQuest
    {
        public event EventHandler<IQuest> Completed;
        public bool IsComplete { get; }

        private QuestObjectView _key;
        private QuestObjectView _door;
        private IQuestModel _keyModel;
        private CoinDoorQuestModel _doorModel;
        private ObjectsInBagView _bag;
        private bool _active;

        public QuestWithDoorsController(IQuestModel keyModel, CoinDoorQuestModel doorModel, QuestObjectView key, QuestObjectView door, ObjectsInBagView bag)
        {
            _keyModel = keyModel;
            _doorModel = doorModel;
            _key = key;
            _door = door;
            _bag = bag;
        }
        
        private void OnDoorContact(LevelObjectsView arg)
        {
            bool complete = false;
            
            if (arg.gameObject != null)
            {
                complete = _doorModel.TryComplete(arg.gameObject);
            }
            
            if (complete)
            {
                _bag.GetItem(_key.Id);
                _door.gameObject.SetActive(false);
                Complete();
            }
        }
        
        private void OnKeyContact(LevelObjectsView arg)
        {
            bool complete = false;
            
            if (arg.gameObject != null && arg.gameObject.activeSelf)
            {
                complete = _keyModel.TryComplete(arg.gameObject);
            }

            if (complete)
            {
                _doorModel.HasKey();
                _bag.AddItem(_key);
                _key.gameObject.SetActive(false);
            }
            
        }
        
        private void Complete()
        {
            if (!_active)
            {
                return;
            }

            _active = false;
            _key.OnLevelObjectContact -= OnKeyContact;
            _door.OnLevelObjectContact -= OnDoorContact;
            OnCompleted();
        }
        
        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }
        
        public void Reset()
        {
            if (_active)
            {
                return;
            }

            _active = true;
            _key.OnLevelObjectContact += OnKeyContact;
            _door.OnLevelObjectContact += OnDoorContact;
        }
        
        public void Dispose()
        {
            _key.OnLevelObjectContact -= OnKeyContact;
            _door.OnLevelObjectContact -= OnDoorContact;
        }
    }
}