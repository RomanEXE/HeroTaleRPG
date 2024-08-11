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
            GameState.FightState.Exit();
            GameState.IdleState.Enter();
        }
    }
}