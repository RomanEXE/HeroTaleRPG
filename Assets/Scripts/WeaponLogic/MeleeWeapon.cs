using Entities;
using Inventory.Items;
using Inventory.Items.WeaponItem;
using Items;
using UnityEngine;

namespace WeaponLogic
{
    public class MeleeWeapon : Weapon
    {
        public MeleeWeapon(WeaponItemSo data, Entity owner) : base(data, owner)
        {
        }

        public override void Attack(Entity target)
        {
            target.ApplyDamage(Data.Damage + Owner.GetData().Stats[StatType.Power]);
        }
    }
}