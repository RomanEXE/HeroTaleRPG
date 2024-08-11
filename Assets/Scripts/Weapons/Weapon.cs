using System;
using UnityEngine;

namespace Weapons
{
    public class Weapon
    {
        public event Action AttackRateEnded;
        public bool InCooldown { get; private set; }
        public WeaponSo Data { get; private set; }

        private Timer _timer;

        public Weapon(WeaponSo data)
        {
            Data = data;
        }
        
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