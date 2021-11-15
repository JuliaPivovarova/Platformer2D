using System;
using Code.Config;
using Code.Controllers;
using Code.View;
using UnityEngine;

namespace Code
{
    public class Main: MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectsView _playerView;
        [SerializeField] private float _groundMoveSpeed = 1f;
        [SerializeField] private GameObject _player;

        private SpriteAnimatorController _playerAnimator;
        //private PlayerController _playerController;
        //private GroundMove _groundMove;

        private void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimSfg");
            //_groundMove = new GroundMove(_player, _groundMoveSpeed);
            //_playerController = new PlayerController(_groundMove);

            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }
            
            _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Idle, true, _animationSpeed);
        }

        private void Update()
        {
            _playerAnimator.Update();
            if (Input.GetKeyDown(KeyCode.D))
            {
                _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Run, true, _animationSpeed);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Run, true, _animationSpeed);
                _player.transform.localScale += (new Vector3(-2, 0, 0));
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _player.transform.localScale += (new Vector3(2, 0, 0));
                _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Jump, true, _animationSpeed);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _playerAnimator.StartAnimation(_playerView.spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
            
            //_playerController.Move();
        }
    }
}