using Code.Controllers;
using UnityEngine;

namespace Code
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float getDamage = -5f;
        
        private HealthController _healthController;
        
        public void Awake()
        {
            _healthController = new HealthController(100f, 100f);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 8)
            {
                _healthController.ChangeCurrentHealth(getDamage);
                Debug.Log("Your current health - " + _healthController.GetCurrentHealth());
            }
        }
    }
}