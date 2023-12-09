using System;
using UnityEngine;
using Zenject;

namespace Services.ForInput
{
    public class InputService : ITickable, IInputService
    {
        public event Action OnInputLeftArrow;
        public event Action OnInputRightArrow;

        public bool IsActive { get; set; } = true;
        
        public void Tick()
        {
            if(!IsActive)
                return;
            
            if(Input.GetKeyDown(KeyCode.LeftArrow))
                OnInputLeftArrow?.Invoke();
            
            if(Input.GetKeyDown(KeyCode.RightArrow))
                OnInputRightArrow?.Invoke();
        }
    }
}