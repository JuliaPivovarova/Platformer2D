using System;
using UnityEngine;

namespace Code.View
{
    public class LevelObjectsView : MonoBehaviour
    {
        public Transform transform;
        public SpriteRenderer spriteRenderer;
        public Collider2D collider;
        public Rigidbody2D rigidbody;

        public Action<LevelObjectsView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LevelObjectsView levelObject = collision.gameObject.GetComponent<LevelObjectsView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}
