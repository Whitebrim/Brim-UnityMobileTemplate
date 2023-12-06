namespace Core.Infrastructure.States
{
    public interface IBaseState
    {
        void Exit();
    }

    public interface IState : IBaseState
    {
        void Enter();
    }

    public interface IPayloadedState<in TPayload> : IBaseState
    {
        void Enter(TPayload payload);
    }
}