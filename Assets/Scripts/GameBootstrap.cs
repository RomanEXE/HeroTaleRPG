using Entities;
using Entities.Enemies;
using GameStates;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private EntityDataSo playerData;
        [SerializeField] private EnemyConfiguration enemyConfiguration;
        
        private void Start()
        {
            Fight.Init();
            GameState.Init();
            enemyConfiguration.Init();
            
            Fight.Player.Init(playerData);
            
            GameState.IdleState.Enter();

            Timer.Register(this, 1, delegate
            {
                GameState.IdleState.Exit();
                GameState.FightState.Enter();
            });
        }
    }
}