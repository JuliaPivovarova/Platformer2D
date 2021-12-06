using System.Collections.Generic;
using Code.Config;
using Code.Controllers;
using Code.View;
using UnityEngine;

namespace Code
{
    public class Main: MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig playerConfig;
        [SerializeField] private SpriteAnimatorConfig coinsAnimCfg;
        [SerializeField] private LevelObjectsView playerView;
        [SerializeField] private float groundMoveSpeed = 1f;
        [SerializeField] private GameObject player;
        [SerializeField] private CannonView cannonView;
        [SerializeField] private List<LevelObjectsView> coinsViews;
        [SerializeField] private float distanceToPlayerForCannon = 4f;
        [SerializeField] private GeneratorLevelView genView;
        [SerializeField] private QuestView questView;
        [SerializeField] private QuestWithDoorView questWithDoorView;
        [SerializeField] private ObjectsInBagView bagView;

        private SpriteAnimatorController _playerAnimator;
        private CameraController _cameraController;
        private SpriteAnimatorController _coinAnimator;
        private PlayerController _playerController;
        private GroundMove _groundMove;
        private BulletEmitterController _bulletEmitterController;
        private CannonAimController _cannon;
        private CoinsController _coinsController;
        private GeneratorController _levelController;
        private QuestConfiguratorController _questConfigurator;
        private QuestWithDoorConfiguratorController _questWithDoorConfigurator;

        private void Start()
        {
            playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimSfg");
            coinsAnimCfg = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");
            _groundMove = new GroundMove(player, groundMoveSpeed);
            

            if (playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(playerConfig);
            }
            
            if (coinsAnimCfg)
            {
                _coinAnimator = new SpriteAnimatorController(coinsAnimCfg);
            }
            
            _playerAnimator.StartAnimation(playerView.spriteRenderer, AnimState.Idle, true);
            _playerController = new PlayerController(_groundMove, playerView, _playerAnimator);
            _cameraController = new CameraController(playerView.transform, Camera.main.transform);
            
            _cannon = new CannonAimController (cannonView._muzzleTransform, playerView.transform, distanceToPlayerForCannon);
            _bulletEmitterController = new BulletEmitterController(cannonView._bullets, cannonView._emitterTransform, playerView.transform, distanceToPlayerForCannon);

            _coinsController = new CoinsController(playerView, coinsViews, _coinAnimator);

            _levelController = new GeneratorController(genView);
            _levelController.Init();

            _questConfigurator = new QuestConfiguratorController(questView);
            _questConfigurator.Init();

            _questWithDoorConfigurator = new QuestWithDoorConfiguratorController(questWithDoorView, bagView);
            _questWithDoorConfigurator.Init();
        }

        private void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
            _coinAnimator.Update();
            _cameraController.Update();
        }
    }
}