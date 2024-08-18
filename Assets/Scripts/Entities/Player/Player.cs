using System;
using Inventory.Items;
using Items;
using UnityEngine;

namespace Entities.Player
{
    public class Player : Entity
    {
        public event Action PlayerDied;
        public PlayerSo Data;
        
        public Inventory.Inventory Inventory => inventory;

        [SerializeField] private Inventory.Inventory inventory;
        
        public override void Init()
        {
            base.Init();
            Data.PlayerExp.Init();
            inventory.Init();
        }

        protected override void Die()
        {
            base.Die();
            
            PlayerDied?.Invoke();
            Data.CurrentHp = 1;
        }

        public void Heal()
        {
            Data.CurrentHp = (int)Data.Stats[StatType.MaxHp];
        }

        protected override Entity GetTarget()
        {
            return Entities.Enemy;
        }

        public override EntityDataSo GetData()
        {
            return Data;
        }
    }
}