using Core.Infrastructure.Services;
using Core.Services;
using Core.Services.AssetManagement;

namespace Core.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ServiceLocator _services;

        public BootstrapState(GameStateMachine stateMachine, ServiceLocator services, VariableAssets assetManager)
        {
            _stateMachine = stateMachine;
            _services = services;
            RegisterServices(assetManager);
        }

        public void Enter()
        {
            EnterLoadLevel();
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>(SceneName.MainMenu);

        private void RegisterServices(VariableAssets assetManager)
        {
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(_services.Single<ICoroutineRunner>()));
            _services.RegisterSingle<IAssetProvider>(new AddressablesProvider());
            _services.RegisterSingle<VariableAssets>(assetManager);
        }
    }
}