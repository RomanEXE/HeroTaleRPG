using Entities;
using Entities.Enemies;
using GameStates;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private EntityDataSo playerData;
        [SerializeField] private EnemyConfiguration enemyConfiguration;
        [SerializeField] private GameState gameState;
        [SerializeField] private HealButton healButton;
        
        private void Start()
        {
            Fight.Init();
            enemyConfiguration.Init();
            healButton.Init();
            Fight.Player.Init(playerData);
            
            gameState.SetIdleState();
        }
    }
}