namespace HeroLogic
{
    public interface IFlipper
    {
        bool IsFlip { get; }
        void FlipRight();
        void FlipLeft();
    }
}