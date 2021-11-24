using System.Collections.Generic;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class BulletEmitterController
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;
        private Transform _playerTransform;
        private float _distanceToTrow;
    
        private int _currentIndex;
        private float _timeTillNextBullet;
    
        private float _delay = 1f;
        private float _startSpeed = 10f;
    
        public BulletEmitterController (List<LevelObjectsView> bulletView, Transform transform, Transform playerTransform, float distanceToTrow)
        {
            _transform = transform;
            _playerTransform = playerTransform;
            _distanceToTrow = distanceToTrow;
            foreach (LevelObjectsView BulletView in bulletView)
            {
                _bullets.Add (new BulletController (BulletView));
            }
        }
    
    
        public void Update()
        {
            if (Vector3.Distance(_transform.position, _playerTransform.position) <= _distanceToTrow)
            {
                if (_timeTillNextBullet > 0)
                {
                    _bullets[_currentIndex].Active(false);
                    _timeTillNextBullet -= Time.deltaTime;
                }
                else
                {
                    _timeTillNextBullet = _delay;
                    _bullets[_currentIndex].Trow(_transform.position, -_transform.up * _startSpeed);
                    _currentIndex++;
                    if(_currentIndex >= _bullets.Count)
                    {
                        _currentIndex = 0;
                    }
                }
            }            
        }
    }
}
