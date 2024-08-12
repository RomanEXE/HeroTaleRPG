using System;
using DefaultNamespace;
using UnityEngine;

namespace Entities.Player
{
    public class Player : Entity
    {
        public event Action PlayerDied;
        public PlayerSo Data;
        [SerializeField] private PlayerExp playerExp;

        public override void Init()
        {
            base.Init();
            playerExp.Init();
        }

        protected override void Die()
        {
            base.Die();
            
            PlayerDied?.Invoke();
        }

        public void Heal()
        {
            Data.CurrentHp = Data.MaxHp;
        }

        protected override Entity GetTarget()
        {
            return Fight.Enemy;
        }

        public override EntityDataSo GetData()
        {
            return Data;
        }
    }
}