using VContainer;

namespace Core.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private GameStateMachine _stateMachine;

        [Inject]
        public void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            EnterLoadLevel();
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>(SceneName.MainMenu);
    }
}