using UnityEngine;

namespace Code.Controllers
{
    public class TeleportController: MonoBehaviour
    {
        [SerializeField] private Transform otherPointToTeleport;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 7 || other.gameObject.layer == 9)
            {
                other.transform.position = otherPointToTeleport.position;
            }
        }
    }
}
