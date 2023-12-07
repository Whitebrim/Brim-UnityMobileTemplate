using System;

namespace Core.Services.SceneLoader
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoad = null);
    }
}