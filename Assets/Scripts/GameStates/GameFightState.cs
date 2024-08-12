using System;
using DefaultNamespace;
using States;
using States.GameStateMachine;
using UnityEngine;

namespace GameStates
{
    public class GameFightState : IState
    {
        public event Action FightStarted;
        
        public void Enter()
        {
            Debug.Log("set fight state");
            FightStarted?.Invoke();
            Fight.Enemy.EnemyDied += OnEntityDied;
            Fight.Player.PlayerDied += OnEntityDied;
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            Fight.Enemy.EnemyDied -= OnEntityDied;
            Fight.Player.PlayerDied -= OnEntityDied;
        }
        
        private void OnEntityDied()
        {
            GameState.SetIdleState();
        }
    }
}