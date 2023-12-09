using System;

namespace Infrastructure.General
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onLoad = null);
    }
}