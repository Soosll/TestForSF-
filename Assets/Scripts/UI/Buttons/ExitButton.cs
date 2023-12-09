using UnityEngine;
using Application = UnityEngine.Application;

namespace UI.Buttons
{
    public class ExitButton : MonoBehaviour
    {
        public void Exit() => 
            Application.Quit();
    }
}