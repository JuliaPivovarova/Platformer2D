using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(fileName = "QuestStoryCfg", menuName = "Configs / Quest Story Cfg", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }
}