using Code.Model;
using Code.View;

namespace Code.Controllers
{
    public class QuestWithDoorConfiguratorController
    {
        private QuestObjectView _key;
        private QuestObjectView _door;
        private QuestWithDoorsController _questWithDoor;
        private CoinDoorQuestModel _doorModel;
        private CoinQuestModel _keyModel;
        private ObjectsInBagView _bag;

        public QuestWithDoorConfiguratorController(QuestWithDoorView questWithDoorView, ObjectsInBagView bag)
        {
            _bag = bag;
            _key = questWithDoorView.keyForDoor;
            _door = questWithDoorView.door;
            _doorModel = new CoinDoorQuestModel();
            _keyModel = new CoinQuestModel();
        }

        public void Init()
        {
            _questWithDoor = new QuestWithDoorsController(_keyModel, _doorModel, _key, _door, _bag);
            _questWithDoor.Reset();
        }
    }
}