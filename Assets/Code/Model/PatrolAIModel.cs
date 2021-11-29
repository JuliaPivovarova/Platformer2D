using UnityEngine;

namespace Code.Model
{
    public class PatrolAIModel
    {
        private readonly Transform[] _wayPionts;
        private int _currentPointIndex;

        public PatrolAIModel(Transform[] wayPionts)
        {
            _wayPionts = wayPionts;
            _currentPointIndex = 0;
        }

        public Transform GetNextTarget()
        {
            if (_wayPionts == null) return null;
            _currentPointIndex = (_currentPointIndex + 1) % _wayPionts.Length;
            return _wayPionts[_currentPointIndex];
        }

        public Transform GetClosestTarget(Vector2 fromPosition)
        {
            if (_wayPionts == null) return null;

            var closestIndex = 0;
            var closetDistance = 0.0f;

            for (int i = 0; i < _wayPionts.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition, _wayPionts[i].position);
                if (closetDistance > distance)
                {
                    closetDistance = distance;
                    closestIndex = i;
                }
            }
            _currentPointIndex = closestIndex;
            return _wayPionts[_currentPointIndex];
        }
    }
}