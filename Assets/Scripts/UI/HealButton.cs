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
        }

        private void OnEnable()
        {
            owner.onClick.AddListener(Heal);
        }

        private void OnDisable()
        {
            owner.onClick.RemoveAllListeners();
        }
        
        private void Heal()
        {
           player.Heal(); 
        }
    }
}