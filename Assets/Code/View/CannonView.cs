using System.Collections.Generic;
using UnityEngine;

namespace Code.View
{
    public class CannonView : MonoBehaviour
    {
        public Transform _muzzleTransform;
        public Transform _emitterTransform;
        public List<LevelObjectsView> _bullets;
    }
}
