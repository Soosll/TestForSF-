using EnemyLogic;
using UnityEngine;

namespace Infrastructure.Factories.ForEnemy
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(EnemyTypeID enemyID, Transform parent);
    }
}