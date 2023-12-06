using Core.Infrastructure.Services;
using Core.Services.AssetManagement;

namespace Core.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ServiceLocator _services;
        private readonly IAssetProvider _assetProvider;

        public GameLoopState(GameStateMachine stateMachine, ServiceLocator services, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
            _services = services;
            _assetProvider = assetProvider;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}