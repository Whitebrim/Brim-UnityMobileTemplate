using Core.Infrastructure.States;
using VContainer;

namespace Core.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        [Inject]
        private void Construct(GameStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
    }
}