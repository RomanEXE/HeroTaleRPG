using States.EntityStateMachine;

namespace States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}