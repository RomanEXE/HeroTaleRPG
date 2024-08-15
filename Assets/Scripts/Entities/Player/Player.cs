using System;
using UnityEngine;

namespace Entities.Player
{
    public class Player : Entity
    {
        public event Action PlayerDied;
        public PlayerSo Data;

        public override void Init()
        {
            base.Init();
            Data.PlayerExp.Init();
            Data.Inventory.Init();
        }

        protected override void Die()
        {
            base.Die();
            
            PlayerDied?.Invoke();
            Data.CurrentHp = 1;
        }

        public void Heal()
        {
            Data.CurrentHp = Data.MaxHp;
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