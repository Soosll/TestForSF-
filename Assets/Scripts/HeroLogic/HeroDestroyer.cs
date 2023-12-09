using System;
using Services.ForDispose;
using Services.ForInput;
using UnityEngine;
using Zenject;
using IDisposable = Services.ForDispose.IDisposable;

namespace HeroLogic
{
    public class HeroDestroyer : MonoBehaviour, IDisposable
    {
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private HeroAttacker _heroAttacker;
        
        private IInputService _inputService;
        private IDisposeService _disposeService;

        public bool NeedToClear { get; set; }

        [Inject]
        public void Construct(IInputService inputService, IDisposeService disposeService)
        {
            _inputService = inputService;
            _disposeService = disposeService;
        }

        public void Dispose()
        {
            _disposeService.RemoveDisposableElement(this);
            
            Destroy(gameObject);
        }
        
        private void OnEnable()
        {
            Subscribe();
            
            _disposeService.AddDisposableElement(this);
        }

        private void Subscribe() => 
            _heroHealth.OnHealthIsOver += RunDeathLogic;

        private void RunDeathLogic()
        {
            _heroAnimator.PlayDeath();
            _heroAttacker.enabled = false;
            _inputService.IsActive = false;
        }

        private void CleanUp() => 
            _heroHealth.OnHealthIsOver -= RunDeathLogic;

        private void OnDisable() => 
            CleanUp();
    }
}