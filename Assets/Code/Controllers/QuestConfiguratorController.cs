using Code.Model;
using Code.View;

namespace Code.Controllers
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuest;
        private CoinQuestModel _model;

        public QuestConfiguratorController(QuestView questView)
        {
            _singleQuestView = questView._singleQuest;
            _model = new CoinQuestModel();
        }

        public void Init()
        {
            _singleQuest = new QuestController(_singleQuestView, _model);
            _singleQuest.Reset();
        }
    }
}