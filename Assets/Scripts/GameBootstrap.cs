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
        healButton.Init();
        enemyConfiguration.Init();
        Fight.Player.Init(playerData);
            
        GameState.SetIdleState();
    }
}