using System;
using GameStates;

namespace States.GameStateMachine
{
    public class GameFightState : IState
    {
        public event Action FightStarted;
        
        public void Enter()
        {
            FightStarted?.Invoke();
            Entities.Entities.Enemy.EnemyDied += OnEntityDied;
            Entities.Entities.Player.PlayerDied += OnEntityDied;
        }

        public void Exit()
        {
            Entities.Entities.Enemy.EnemyDied -= OnEntityDied;
            Entities.Entities.Player.PlayerDied -= OnEntityDied;
        }
        
        private void OnEntityDied()
        {
            GameState.SetIdleState();
        }
    }
}