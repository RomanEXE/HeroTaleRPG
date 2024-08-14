using System;
using DefaultNamespace;
using GameStates;

namespace States.GameStateMachine
{
    public class GameFightState : IState
    {
        public event Action FightStarted;
        
        public void Enter()
        {
            FightStarted?.Invoke();
            Fight.Enemy.EnemyDied += OnEntityDied;
            Fight.Player.PlayerDied += OnEntityDied;
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