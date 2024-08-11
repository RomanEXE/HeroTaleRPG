using DefaultNamespace;
using UnityEngine;
using Weapons;

namespace Entities.Player
{
    public class Player : Entity
    {
        [SerializeField] private float attackDelay;
        
        public void ChangeWeapon(WeaponSo weaponData)
        {
            AttackLogic.ChangeWeapon(weaponData);
        }

        protected override void OnFightStarted()
        {
            WaitAttackDelay();
        }

        private void WaitAttackDelay()
        {
            Timer.Register(this, attackDelay, OnWaitAttackDelayComplete);
        }

        private void OnWaitAttackDelayComplete()
        {
            AttackLogic.StartAttack(Fight.Enemy);
        }
    }
}