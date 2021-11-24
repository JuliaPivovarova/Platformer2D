using UnityEngine;

namespace Code.Controllers
{
    public class CannonAimController
    {
        private Transform _muzzleTransform;
        private Transform _targetTransform;

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axes;
        private float _distanceToAim;

        public CannonAimController(Transform muzzleTransform, Transform targetTransform, float distanceToAim)
        {
            _muzzleTransform = muzzleTransform;
            _targetTransform = targetTransform;
            _distanceToAim = distanceToAim;
        }
    
        public  void Update()
        {
            if (Vector3.Distance(_muzzleTransform.position, _targetTransform.position) <= _distanceToAim)
            {
                _dir = _targetTransform.position - _muzzleTransform.position;
                _angle = Vector3.Angle(Vector3.down, _dir);

                _axes = Vector3.Cross(Vector3.down, _dir);
                _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axes);
            }
        }
    }
}
