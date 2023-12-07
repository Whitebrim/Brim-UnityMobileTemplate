using Core.Services.AssetManagement;
using VContainer;

namespace Core.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private GameStateMachine _stateMachine;
        private IAssetProvider _assetProvider;

        [Inject]
        private void Construct(GameStateMachine stateMachine, IAssetProvider assetProvider)
        {
            _stateMachine = stateMachine;
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