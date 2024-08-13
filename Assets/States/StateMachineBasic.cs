using System.Collections.Generic;

namespace States
{
    public class StateMachineBasic<T>
    {
        public Dictionary<T, IState> States;
        public IState CurrentState => _currentState;
        private IState _currentState;

        public virtual void ChangeState(T state)
        {
            IState newState = States[state];
            
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}