using Core.Infrastructure.States;
using Sirenix.OdinInspector;

namespace UI.Mediator
{
    class MainMenuMediator : Mediator
    {
        [Button("Play")]
        public void Play()
        {
            StateMachine.Enter<LoadLevelState, string>(SceneName.Game);
        }
    }
}