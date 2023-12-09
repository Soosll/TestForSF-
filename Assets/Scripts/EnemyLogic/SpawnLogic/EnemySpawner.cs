using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Factories.ForEnemy;
using Services.ForDispose;
using UnityEngine;
using Zenject;
using IDisposable = Services.ForDispose.IDisposable;
using Random = System.Random;

namespace EnemyLogic.SpawnLogic
{
    public class EnemySpawner : MonoBehaviour, IDisposable
    {
        [SerializeField] private float _spawnDelay;

        private SpawnPoint[] _spawnPoints;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private bool _needSpawn = true;

        private IEnemyFactory _enemyFactory;
        private IDisposeService _disposeService;

        public bool NeedToClear { get; set; } = true;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory, IDisposeService disposeService)
        {
            _enemyFactory = enemyFactory;
            _disposeService = disposeService;
        }

        private void Awake()
        {
            _spawnPoints = GetComponentsInChildren<SpawnPoint>();

            _disposeService.AddDisposableElement(this);
        }

        public void RunSpawnLogic()
        {
            SpawnEnemies();
            StartCoroutine(SpawnTimer());
        }

        public void Dispose()
        {
            _disposeService.RemoveDisposableElement(this);
            
            foreach (Enemy enemy in _spawnedEnemies)
            {
                if (enemy != null)
                    Destroy(enemy.gameObject);
            }

            _spawnedEnemies.Clear();
        }
        
        private IEnumerator SpawnTimer()
        {
            while (_needSpawn)
            {
                yield return new WaitForSeconds(_spawnDelay);
                SpawnEnemies();
            }
        }

        private void SpawnEnemies()
        {
            GetRandomEnumEnemy();


            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                var enemyEnumValue = GetRandomEnumEnemy();
                
                var enemy = _enemyFactory.CreateEnemy(enemyEnumValue, _spawnPoints[i].transform);
                _spawnedEnemies.Add(enemy);
            }
        }

        private EnemyTypeID GetRandomEnumEnemy()
        {
            var values = Enum.GetValues(typeof(EnemyTypeID));

            EnemyTypeID randomValue = (EnemyTypeID)values.GetValue(UnityEngine.Random.Range(0, values.Length));

            return randomValue;
        }
    }
}