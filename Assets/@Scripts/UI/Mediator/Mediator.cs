using Core.Infrastructure.States;
using UnityEngine;
using VContainer;

namespace UI.Mediator
{
    public abstract class Mediator : MonoBehaviour
    {
        protected GameStateMachine StateMachine;

        [Inject]
        protected void Construct(GameStateMachine StateMachine)
        {
            this.StateMachine = StateMachine;
        }
    }
}
