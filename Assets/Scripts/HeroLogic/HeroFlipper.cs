using Services.ForDispose;
using Services.ForInput;
using UnityEngine;

namespace HeroLogic
{
    public class HeroFlipper : IFlipper, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly IDisposeService _disposeService;

        private readonly SpriteRenderer _spriteRenderer;

        public bool IsFlip { get; private set; }
        
        public bool NeedToClear { get; set; }

        public HeroFlipper(IInputService inputService,IDisposeService disposeService, SpriteRenderer spriteRenderer)
        {
            _inputService = inputService;
            _disposeService = disposeService;
            _spriteRenderer = spriteRenderer;
            
            Subscribe();
        }

        private void Subscribe()
        {
            _inputService.OnInputRightArrow += FlipRight;
            _inputService.OnInputLeftArrow += FlipLeft;
            
            _disposeService.AddDisposableElement(this);
        }

        private void CleanUp()
        {
            _inputService.OnInputRightArrow -= FlipRight;
            _inputService.OnInputLeftArrow -= FlipLeft;
            
            _disposeService.RemoveDisposableElement(this);
        }

        public void FlipRight()
        {
            IsFlip = false;
            _spriteRenderer.flipX = false;
        }

        public void FlipLeft()
        {
            IsFlip = true;
            _spriteRenderer.flipX = true;
        }

        public void Dispose() => 
            CleanUp();
    }
}