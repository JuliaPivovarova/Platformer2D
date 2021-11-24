namespace Code.Controllers
{
    public class HealthController
    {
        private float _max;
        private float _current;

        public HealthController(float max, float current)
        {
            _max = max;
            _current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            _current += hp;
        }

        public float GetCurrentHealth()
        {
            return _current;
        }
    }
}