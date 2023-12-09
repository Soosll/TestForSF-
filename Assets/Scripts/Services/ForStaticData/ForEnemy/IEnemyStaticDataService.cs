using EnemyLogic;
using StaticData.ForEnemy;

namespace Services.ForStaticData.ForEnemy
{
    public interface IEnemyStaticDataService
    {
        EnemyStaticData ForEnemy(EnemyTypeID enemyID);
        void Load();
    }
}