using Code.Config;
using Code.Controllers;
using Code.View;
using UnityEngine;

namespace Code
{
    public class Main: MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig playerConfig;
        [SerializeField] private LevelObjectsView playerView;
        [SerializeField] private float groundMoveSpeed = 1f;
        [SerializeField] private GameObject player;

        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        private GroundMove _groundMove;

        private void Start()
        {
            playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimSfg");
            _groundMove = new GroundMove(player, groundMoveSpeed);
            

            if (playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(playerConfig);
            }
            
            _playerAnimator.StartAnimation(playerView.spriteRenderer, AnimState.Idle, true);
            _playerController = new PlayerController(_groundMove, playerView, _playerAnimator);
        }

        private void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
        }
    }
}