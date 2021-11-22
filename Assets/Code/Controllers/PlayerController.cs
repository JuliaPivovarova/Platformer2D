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
        private bool _isdoubleJump = false;
        private bool _isHoldingAtVerticale = false;
        private bool _isCrouch;
        
        private float _walkSpeed = 160f;
        private float _movingTreshold = 0.1f; 
        
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        
        private bool _isMoving;
        
        private float _jumpSpeed = 9f;
        private float _jumpTreshold = 1f;
        private float _yVelocity;
        private float _xVelocity;

        private LevelObjectsView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactPooler _contactPooler;

        public PlayerController(IMove move, LevelObjectsView view, SpriteAnimatorController spriteAnimator)
        {
            _move = move;
            _view = view;
            _spriteAnimator = spriteAnimator;
            _contactPooler = new ContactPooler(_view.collider);
        }

        private void MoveTorwards()
        {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _view.rigidbody.velocity = _view.rigidbody.velocity.Change(x: _xVelocity);
            _view.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        //public void Move()
        //{
        //    _move.Move();
        //}
        
        public void Update()
        {
            _spriteAnimator.Update();
            _contactPooler.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0 || Input.GetAxis("Jump") > 0;
            _isCrouch = Input.GetAxis("Vertical") < 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            
            if(_isMoving)
            {
                MoveTorwards();
            }
            
            if(_contactPooler.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view.spriteRenderer, _isMoving ? AnimState.Run:AnimState.Idle, true);

                _isdoubleJump = false;
                if (_isJump && Mathf.Abs(_view.rigidbody.velocity.y) <= _jumpTreshold)
                {
                    _view.rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
                if (_isCrouch)
                {
                    _spriteAnimator.StartAnimation(_view.spriteRenderer, AnimState.Crouch, true);
                }
            }
            else
            {
                if (Math.Abs(_view.rigidbody.velocity.y) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view.spriteRenderer, AnimState.Jump, true);

                    if(!_isdoubleJump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
                    {                        
                        _view.rigidbody.velocity = Vector2.zero;
                        _view.rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                        _isdoubleJump = true;
                    }

                    if (_contactPooler.HasLeftContact || _contactPooler.HasRightContact)
                    {
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            _view.rigidbody.velocity = Vector2.zero;
                            _view.rigidbody.gravityScale = 0.2f;
                        }

                        if (Input.GetKeyUp(KeyCode.F))
                        {
                            _view.rigidbody.gravityScale = 1f;
                        }
                    }
                }
            }
        }
    }
}