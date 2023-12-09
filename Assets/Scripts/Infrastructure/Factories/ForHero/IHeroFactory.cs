using UnityEngine;

namespace Infrastructure.Factories.ForHero
{
    public interface IHeroFactory
    {
        GameObject CreateHero(Transform point);
    }
}