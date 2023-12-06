using Core.Infrastructure.Services;
using Core.Infrastructure.States;
using Core.Services;
using Core.Services.AssetManagement;

namespace Core.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, VariableAssets assetManager)
        {
            StateMachine = new GameStateMachine(ServiceLocator.Container, assetManager);
        }
    }
}