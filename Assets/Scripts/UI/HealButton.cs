using System;
using Entities.Player;
using GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealButton : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Button owner;

        private void OnDestroy()
        {
            GameState.IdleState.IdleStateStarted -= ShowButton;
            GameState.FightState.FightStarted -= HideButton;
            owner.onClick.RemoveAllListeners();
        }

        public void Init()
        {
            GameState.IdleState.IdleStateStarted += ShowButton;
            GameState.FightState.FightStarted += HideButton;
            owner.onClick.AddListener(Heal);
        }

        private void ShowButton()
        {
            gameObject.SetActive(true);
        }
        
        private void HideButton()
        {
            gameObject.SetActive(false);
        }
        
        private void Heal()
        {
           player.Heal(); 
        }
    }
}