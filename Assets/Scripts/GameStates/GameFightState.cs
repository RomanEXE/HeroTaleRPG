using System;
using DefaultNamespace;
using States;

namespace GameStates
{
    public class GameFightState : IState
    {
        public event Action FightStarted;
        
        public void Enter()
        {
            FightStarted?.Invoke();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}