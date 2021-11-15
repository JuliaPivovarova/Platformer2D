using System;
using Code.Interfaces;
using UnityEngine;

namespace Code
{
    public class GroundMove: IMove
    {
        private float _groundMoveSpeed;
        private readonly GameObject _player;

        public GroundMove(GameObject player, float groundMoveSpeed)
        {
            _player = player;
            _groundMoveSpeed = groundMoveSpeed;
        }

        public void Move()
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Jump"));
            if (_player.TryGetComponent<Rigidbody2D>(out var rigidbody))
            {
                rigidbody.AddForce(_groundMoveSpeed * movement);
            }
            else
            {
                throw new Exception("There is no Rigidbody");
            }
        }
    }
}