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
            Fight.Enemy.EnemyDied += OnEnemyDied;
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            Fight.Enemy.EnemyDied -= OnEnemyDied;
        }
        
        private void OnEnemyDied()
        {
            GameState.FightState.Exit();
            GameState.IdleState.Enter();
        }
    }
}