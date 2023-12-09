using UnityEngine;
using Zenject;

namespace Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly IInstantiator _instantiator;

        public AssetProvider(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public GameObject Instantiate(string path)
        {
            var loadedGameObject = LoadGameObject(path);

            return _instantiator.InstantiatePrefab(loadedGameObject);
        }

        public GameObject Instantiate(string path, Transform at)
        {
            var loadedGameObject = LoadGameObject(path);

            return _instantiator.InstantiatePrefab(loadedGameObject, at);
        }

        private GameObject LoadGameObject(string path) => 
            Resources.Load<GameObject>(path);
    }
    
}