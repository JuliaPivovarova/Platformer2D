using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class BulletController
    {
        private Vector3 _velocity;
        private LevelObjectsView _view;
    
        public BulletController (LevelObjectsView view)
        {
            _view = view;
            Active(false);
        }
    
        public void Active (bool val)
        {
            _view.gameObject.SetActive(val);
        }
    
        public void SetVelocity (Vector3 velocity)
        {
            _velocity = velocity;
            float angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    
        public void Trow (Vector3 position, Vector3 velocity)
        {
            Active(true);
            SetVelocity(velocity);
            _view.transform.position = position;
            _view.rigidbody.velocity = Vector2.zero;
            _view.rigidbody.AddForce(velocity , ForceMode2D.Impulse);
        }
    }
}
