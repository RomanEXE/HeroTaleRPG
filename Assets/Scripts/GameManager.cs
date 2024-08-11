using System;
using GameStates;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Fight.Init();
            GameState.Init();
            
            Fight.Enemy.Init();
            Fight.Player.Init();
            
            GameState.FightState.Enter();

            Timer.Register(this, 2, delegate
            {
                GameState.FightState.Exit();
                GameState.IdleState.Enter();
            });
        }
    }
}