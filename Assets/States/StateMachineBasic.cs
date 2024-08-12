using System.Collections.Generic;

namespace States
{
    public class StateMachineBasic<T>
    {
        public Dictionary<T, IState> States;
        private IState _currentState;

        public void ChangeState(T state)
        {
            IState newState = States[state];

            if (newState == _currentState)
            {
                return;
            }
            
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }
}