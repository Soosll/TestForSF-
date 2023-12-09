using HeroLogic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyFlipper : IFlipper
    {
        private readonly SpriteRenderer _spriteRenderer;
        public bool IsFlip { get; private set; }

        public EnemyFlipper(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }
        
        public void FlipRight()
        {
            SetRendererFlipX(false);
        }

        public void FlipLeft()
        {
            SetRendererFlipX(true);
        }

        private void SetRendererFlipX(bool value)
        {
            _spriteRenderer.flipX = value;
            IsFlip = value;
        }
    }
}