using UnityEngine;

namespace Code.View
{
    public class QuestObjectView : LevelObjectsView
    {
        
        [SerializeField] private Color completedColor;
        [SerializeField] private Color defaultColor;
        [SerializeField] private int id;
        
        //private int _id;
        
        public int Id
        {
            get => id;
            set => id = value;
        }
        private void Awake()
        {
            defaultColor = spriteRenderer.color;
        }

        public void ProcessComplete()
        {
            spriteRenderer.color = completedColor;
        }

        public void ProcessActivate()
        {
            spriteRenderer.color = defaultColor;
        }
    }
}