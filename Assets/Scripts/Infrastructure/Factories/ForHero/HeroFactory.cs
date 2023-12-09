using HeroLogic;
using Infrastructure.AssetManagement;
using Infrastructure.Handlers.HeroHandler;
using Services.ForDispose;
using Services.ForInput;
using UnityEngine;

namespace Infrastructure.Factories.ForHero
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;
        private readonly IHeroHandler _heroHandler;
        private readonly IDisposeService _disposeService;

        public HeroFactory(IAssetProvider assetProvider, IInputService inputService, IHeroHandler heroHandler, IDisposeService disposeService)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
            _heroHandler = heroHandler;
            _disposeService = disposeService;
        }
        
        public GameObject CreateHero(Transform point)
        {
            var heroGameObject = _assetProvider.Instantiate(AssetPath.HeroPath, point);

            Hero hero = heroGameObject.GetComponent<Hero>();

            SpriteRenderer heroSpriteRenderer = hero.GetComponent<SpriteRenderer>();
            
            IFlipper heroFlipper = new HeroFlipper(_inputService, _disposeService, heroSpriteRenderer);
            
            AttackCollider attackCollider = hero.GetComponentInChildren<AttackCollider>();
            attackCollider.InitFlipper(heroFlipper);
            attackCollider.Disable();

            HeroAttacker heroAttacker = hero.GetComponent<HeroAttacker>();
            heroAttacker.InitComponents(attackCollider, _inputService);
            
            _heroHandler.Hero = hero;
            
            return heroGameObject;
        }
    }
}