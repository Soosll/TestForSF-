using HeroLogic;
using Services.ForDispose;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Hero
{
    public class HeroHUD : MonoBehaviour, IDisposable
    {
        [SerializeField] private TMP_Text _healthCountText;
        [SerializeField] private TMP_Text _killedCountText;
        
        private HeroHealth _heroHealth;
        private HeroAttacker _heroAttacker;
        
        private IDisposeService _disposeService;

        public bool NeedToClear { get; set; } = true;

        [Inject]
        public void Construct(IDisposeService disposeService) => 
            _disposeService = disposeService;

        public void InitComponents(HeroHealth heroHealth, HeroAttacker heroAttacker)
        {
            _heroHealth = heroHealth;
            _heroAttacker = heroAttacker;
            
            Subscribe();
            
            _disposeService.AddDisposableElement(this);
            
            UpdateHealthCountText(_heroHealth.Current);
        }

        public void Dispose()
        {
            CleanUP();
            
            _disposeService.RemoveDisposableElement(this);

            Destroy(gameObject);
        }

        private void Subscribe()
        {
            _heroHealth.OnHealthChanged += UpdateHealthCountText;
            _heroAttacker.OnKilledEnemy += UpdateKillCountText;
        }

        private void UpdateHealthCountText(int value) => 
            _healthCountText.text = value.ToString();

        private void UpdateKillCountText(int value) => 
            _killedCountText.text = value.ToString();

        private void CleanUP()
        {
            _heroHealth.OnHealthChanged -= UpdateHealthCountText;
            _heroAttacker.OnKilledEnemy -= UpdateKillCountText;
        }
    }
}