using System;

namespace Services.ForInput
{
    public interface IInputService
    {
        event Action OnInputLeftArrow;
        event Action OnInputRightArrow;
        bool IsActive { get; set; }
    }
}