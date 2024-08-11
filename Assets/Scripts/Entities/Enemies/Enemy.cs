using System;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Entities.Enemies
{
    public class Enemy : Entity
    {
        public event Action EnemyDied;
        
        [SerializeField] private ItemsDropper _dropper;
        
        protected override void Die()
        {
            base.Die();
            EnemyDied?.Invoke();
            
            visual.gameObject.SetActive(false);
        }

        protected override void OnFightStateStarted()
        {
            visual.gameObject.SetActive(true);
            AttackLogic.Target = Fight.Player;
        }

        protected override void OnIdleStateStarted()
        {
            visual.gameObject.SetActive(false);
        }
    }
}