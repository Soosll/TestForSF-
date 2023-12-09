using System;
using Extensions;
using UnityEngine;

namespace HeroLogic
{
    public class AttackCollider : MonoBehaviour
    {
        [SerializeField] private Vector2 _leftAttackColliderPosition;
        [SerializeField] private Vector2 _rightAttackColliderPosition;

        private IFlipper _flipper;

        public event Action<Collider2D> OnTriggerFound;
        
        public void InitFlipper(IFlipper flipper)
        {
            _flipper = flipper;
        }
        
        public void Enable()
        {
            if (_flipper.IsFlip)
            {
                SetPositionAndActivate(_leftAttackColliderPosition);

                return;
            }

            SetPositionAndActivate(_rightAttackColliderPosition);
        }

        public void Disable()
        {
            transform.Diactivate();
            transform.localPosition = Vector3.zero;
        }

        private void SetPositionAndActivate(Vector2 position)
        {
            transform.Activate();
            transform.localPosition = position;
            DragCollider();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerFound?.Invoke(other);
        }

        private void DragCollider()
        {
            transform.localPosition += new Vector3(0, 0.01f, 0);
        }
    }
}