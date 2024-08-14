using DefaultNamespace;
using Entities.Enemies;
using GameStates;
using UI;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private EnemyConfiguration enemyConfiguration;
    [SerializeField] private GameState gameState;
    [SerializeField] private ButtonsVisibility buttonsVisibility;
        
    private void Start()
    {
        gameState.Init();
        Fight.Init();
        buttonsVisibility.Init();
        enemyConfiguration.Init();
        Fight.Player.Init();
            
        GameState.SetIdleState();
    }
}