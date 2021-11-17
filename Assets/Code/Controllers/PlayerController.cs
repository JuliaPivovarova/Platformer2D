using System;
using Code.Config;
using Code.Interfaces;
using Code.Utils;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class PlayerController
    {
        private readonly IMove _move;
        
        private float _xAxisInput;
        private bool _isJump;
        private bool _isCrouch;
        
        private float _walkSpeed = 3f;
        private float _movingTreshold = 0.1f; 
        
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        
        private bool _isMoving;
        
        private float _jumpSpeed = 9f;
        private float _jumpTreshold = 1f;
        private float _g = -9.8f;
        private float _groundedLevel = 0f;
        private float _yVelocity;

        private LevelObjectsView _view;
        private SpriteAnimatorController _spriteAnimator;

        public PlayerController(IMove move, LevelObjectsView view, SpriteAnimatorController spriteAnimator)
        {
            _move = move;
            _view = view;
            _spriteAnimator = spriteAnimator;
        }

        private void MoveTorwards()
        {
            _view.transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }
        
        public bool IsGrounded()
        {
            return _view.transform.position.y <= _groundedLevel && _yVelocity <= 0;
        }

        //public void Move()
        //{
        //    _move.Move();
        //}
        
        public void Update()
        {
            _spriteAnimator.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0 || Input.GetAxis("Jump") > 0;
            _isCrouch = Input.GetAxis("Vertical") < 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            
            if(_isMoving)
            {
                MoveTorwards();
            }
            
            if(IsGrounded())
            {
                _spriteAnimator.StartAnimation(_view.spriteRenderer, _isMoving ? AnimState.Run:AnimState.Idle, true);
                
                if(_isJump && _yVelocity <= 0)
                {
                    _yVelocity = _jumpSpeed;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = float.Epsilon;
                    _view.transform.position = _view.transform.position.Change(y : _groundedLevel);
                }

                if (_isCrouch)
                {
                    _spriteAnimator.StartAnimation(_view.spriteRenderer, AnimState.Crouch, true);
                }
            }
            else
            {
                if (Math.Abs(_yVelocity) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view.spriteRenderer, AnimState.Jump, true);
                }

                _yVelocity += _g * Time.deltaTime;
                _view.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
    }
}