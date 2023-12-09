using EnemyLogic;
using UnityEngine;

namespace StaticData.ForEnemy
{
    [CreateAssetMenu(menuName = "StaticData/Enemy", fileName = "EnemyStaticData", order = 51)]
    public class EnemyStaticData : ScriptableObject
    {
        [Header("Type Of Enemy")]
        [SerializeField] private EnemyTypeID _enemyTypeID;

        [Space(25)]
        [Header("Move Parameters")]
        [SerializeField] private float _speed;
        
        [Space(25)]
        [Header("Attack parameters")]
        [SerializeField] private float _attackCoolDown;
        [SerializeField] private float _distanceBeforeAttack;
        [SerializeField] private int _damage;

        [Space(25)]
        [Header("Die parameters")]
        [SerializeField] private float _destroyTime;
        
        [Space(25)]
        [Header("Enemy Prefab")]
        [SerializeField] private GameObject _prefab;

        public EnemyTypeID EnemyTypeID => _enemyTypeID;

        public float Speed => _speed;
        public float AttackCoolDown => _attackCoolDown;
        public float DestroyTime => _destroyTime;
        public float DistanceBeforeAttack => _distanceBeforeAttack;
        
        public int Damage => _damage;
        
        public GameObject Prefab => _prefab;
    }
}