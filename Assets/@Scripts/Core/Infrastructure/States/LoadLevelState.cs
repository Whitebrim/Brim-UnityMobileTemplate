using Core.Services.SceneLoader;
using VContainer;

namespace Core.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(GameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            //_stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }
    }
}