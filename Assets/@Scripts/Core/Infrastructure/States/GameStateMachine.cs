using VContainer;

namespace Core.Infrastructure.States
{
    public class GameStateMachine
    {
        private IObjectResolver _resolver;
        private IBaseState _currentState;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IBaseState =>
            _resolver.Resolve<TState>();

        private TState ChangeState<TState>() where TState : class, IBaseState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }
    }
}