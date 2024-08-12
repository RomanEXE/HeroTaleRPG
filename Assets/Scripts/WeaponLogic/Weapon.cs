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
        public WeaponItem Data { get; private set; }

        private Timer _timer;

        public Weapon(WeaponItem data)
        {
            Data = data;
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