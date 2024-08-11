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
            //Data = data;
        }
        
        public void WaitAttackRate(MonoBehaviour owner)
        {
            if (InCooldown)
            {
                return;
            }
            
            InCooldown = true;
            //_timer = Timer.Register(owner, Data.AttackDelay, OnComplete);
            _timer = Timer.Register(owner, 1f, OnComplete);
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