using HeroLogic;
using UnityEngine;

namespace EnemyLogic
{
    public class EnemyTargetDistanceChecker
    {
        private readonly Transform _enemyTransform;
        private readonly Hero _target;

        private readonly float _closeDistance;

        public EnemyTargetDistanceChecker(Transform enemyTransform, Hero target, float closeDistance)
        {
            _enemyTransform = enemyTransform;
            _target = target;
            _closeDistance = closeDistance;
        }

        public bool CheckDistance() => 
            (_target.transform.position - _enemyTransform.position).magnitude <= _closeDistance;
    }
}