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
        Entities.Entities.Init();
        buttonsVisibility.Init();
        enemyConfiguration.Init();
        Entities.Entities.Player.Init();
            
        GameState.SetIdleState();
    }
}