using System.Collections.Generic;
using System.Linq;
using EnemyLogic;
using Infrastructure.AssetManagement;
using StaticData.ForEnemy;
using UnityEngine;

namespace Services.ForStaticData.ForEnemy
{
    public class EnemyStaticDataService : IEnemyStaticDataService
    {
        private Dictionary<EnemyTypeID, EnemyStaticData> _staticData;

        public EnemyStaticData ForEnemy(EnemyTypeID enemyID) => 
            _staticData.TryGetValue(enemyID, out EnemyStaticData staticData) ? staticData : null;

        public void Load() =>
            _staticData = Resources
                .LoadAll<EnemyStaticData>(StaticDataPath.EnemyStaticDataPath)
                .ToDictionary(x => x.EnemyTypeID, x => x);
    }
}