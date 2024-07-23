namespace Player.Movement
{
    public interface ISpeedController
    {
        public void ResetSpeed();

        public void MultiplySpeed(float value);
    }
}