using System;
using States;
using UnityEngine;

namespace GameStates
{
    public class GameIdleState : IState
    {
        public event Action IdleStateStarted;
        
        public void Enter()
        {
            Debug.Log("set idle state");
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