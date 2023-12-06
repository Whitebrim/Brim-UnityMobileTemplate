using Core.Infrastructure.Services;
using System;

namespace Core.Services
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoad = null);
    }
}