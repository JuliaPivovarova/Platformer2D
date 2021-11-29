using UnityEngine;

namespace Code
{
    public class SimplePatrolAIModel
    {
        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;

        public SimplePatrolAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWayPoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.minDistanseToTarget)
            {
                _target = GetNextWayPoint();
            }

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _config.speed * direction;
        }

        private Transform GetNextWayPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.wayPoints.Length;
            return _config.wayPoints[_currentPointIndex];
        }
    }
}