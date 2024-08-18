using System;
using Entities;
using Inventory.Items.WeaponItem;
using UnityEngine;

namespace WeaponLogic
{
    public abstract class Weapon
    {
        public event Action AttackRateEnded;
        public bool InCooldown { get; private set; }
        public WeaponItemSo Data { get; private set; }

        private Timer _timer;

        protected Entity Owner;

        public Weapon(WeaponItemSo data, Entity owner)
        {
            Data = data;
            Owner = owner;
        }

        public abstract void Attack(Entity target);
        
        public bool TryWaitAttackRate(MonoBehaviour owner)
        {
            if (InCooldown)
            {
                return false;
            }
            
            InCooldown = true;
            _timer = Timer.Register(owner, Data.AttackDelay, OnComplete);

            return true;
        }

        private void OnComplete()
        {
            InCooldown = false;
            AttackRateEnded?.Invoke();
        }

        public void StopAttackRate()
        {
            _timer?.Cancel();
        }
    }
}