using System;
using States;

namespace GameStates
{
    public class GameIdleState : IState
    {
        public event Action IdleStateStarted;
        
        public void Enter()
        {
            IdleStateStarted?.Invoke();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}