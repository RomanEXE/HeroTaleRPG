using DefaultNamespace;
using Entities;
using Entities.Enemies;
using GameStates;
using UI;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private EntityDataSo playerData;
    [SerializeField] private EnemyConfiguration enemyConfiguration;
    [SerializeField] private GameState gameState;
    [SerializeField] private HealButton healButton;
        
    private void Start()
    {
        gameState.Init();
        Fight.Init();
        enemyConfiguration.Init();
        healButton.Init();
        Fight.Player.Init(playerData);
            
        gameState.SetIdleState();
    }
}