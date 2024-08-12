using DefaultNamespace;
using Entities;
using Inventory.Items.WeaponItem;
using UnityEngine;

namespace WeaponLogic
{
    public class MeleeWeapon : Weapon
    {
        public MeleeWeapon(WeaponItem data) : base(data)
        {
        }

        public override void Attack(Entity target)
        {
            target.ApplyDamage(Data.Damage);
        }
    }
}