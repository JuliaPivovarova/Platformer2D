using System;
using System.Collections.Generic;
using Code.Config;
using Code.View;
using UnityEngine;

namespace Code.Controllers
{
    public class CoinsController : IDisposable
    {
        private LevelObjectsView _playerView;
        private SpriteAnimatorController _coinsAnimator;
        private List<LevelObjectsView> _coinsView;

        public CoinsController(LevelObjectsView player, List<LevelObjectsView> coins,
            SpriteAnimatorController coinAnimator)
        {
            _playerView = player;
            _coinsAnimator = coinAnimator;
            _coinsView = coins;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (LevelObjectsView coinView in _coinsView)
            {
                _coinsAnimator.StartAnimation(coinView.spriteRenderer, AnimState.Run, true);
            }
        }

        private void OnLevelObjectContact(LevelObjectsView contactView)
        {
            if (_coinsView.Contains(contactView))
            {
                _coinsAnimator.StopAnimation(contactView.spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}