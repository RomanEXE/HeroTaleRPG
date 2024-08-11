using UnityEngine;
using Weapons;

namespace Entities
{
    public class AttackLogic
    {
        private Weapon _weapon;
        private Entity _owner;
        private Entity _target;

        public AttackLogic(WeaponSo weaponData, Entity owner)
        {
            _weapon = new Weapon(weaponData);
            _owner = owner;
        }
        
        public void StartAttack(Entity target)
        {
            _target = target;
            
            _weapon.WaitAttackRate(_owner);
            _weapon.AttackRateEnded += Attack;
        }

        protected virtual void Attack()
        {
            _weapon.AttackRateEnded -= Attack;
            //_target.ApplyDamage(_weapon.Data.Damage);
            _target.ApplyDamage(1);
            
            StartAttack(_target);
        }

        public void StopAttack()
        {
            _weapon.AttackRateEnded -= Attack;
            _weapon.StopAttackRate();
        }

        public void ChangeWeapon(WeaponSo data)
        {
            _weapon = new Weapon(data);
        }
    }
}