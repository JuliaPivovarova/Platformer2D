using Code.Interfaces;

namespace Code.Controllers
{
    public class PlayerController
    {
        private readonly IMove _move;

        public PlayerController(IMove move)
        {
            _move = move;
        }

        public void Move()
        {
            _move.Move();
        }
    }
}