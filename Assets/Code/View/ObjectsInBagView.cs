using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.View
{
    public class ObjectsInBagView: MonoBehaviour
    {
        [SerializeField] private Image[] items;

        private int[] _idForObjects;

        public void Start()
        {
            _idForObjects = new int[items.Length];
        }

        public Image[] GetBag()
        {
            return items;
        }

        public void AddItem(QuestObjectView obj)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (_idForObjects[i] == 0 && !items[i].gameObject.activeInHierarchy)
                {
                    items[i].sprite = obj.spriteRenderer.sprite;
                    items[i].gameObject.SetActive(true);
                    _idForObjects[i] = obj.Id;
                    i = items.Length + 1;
                }
                //throw new Exception("There is not enough space in bag");
            }
        }

        public void GetItem(int id)
        {
            for (int i = 0; i < _idForObjects.Length; i++)
            {
                if (id == _idForObjects[i])
                {
                    items[i].sprite = null;
                    items[i].gameObject.SetActive(false);
                    _idForObjects[i] = 0;
                }
            }
        }
    }
}