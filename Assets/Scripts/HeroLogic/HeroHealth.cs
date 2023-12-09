using System;
using UnityEngine;

namespace HeroLogic
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        private bool _isDie;

        public int Current => _health;
        
        public event Action OnHealthIsOver;
        public event Action<int> OnHealthChanged;

        public void TakeDamage(int value)
        {
            if(_isDie)
                return;
            
            _health -= value;

            if (_health <= 0)
            {
                _health = 0;
                OnHealthIsOver?.Invoke();
                _isDie = true;
            }

            OnHealthChanged?.Invoke(_health);
        }
    }
}