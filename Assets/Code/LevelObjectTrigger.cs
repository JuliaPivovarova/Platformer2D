using System;
using UnityEngine;

namespace Code
{
    public class LevelObjectTrigger: MonoBehaviour
    {
        [SerializeField] private Collider2D player;
        
        public event EventHandler<GameObject> TriggerEnter;
        public event EventHandler<GameObject> TriggerExit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == player)
            {
                TriggerEnter?.Invoke(this, other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other == player)
            {
                TriggerExit?.Invoke(this, other.gameObject);
            }
        }
    }
}