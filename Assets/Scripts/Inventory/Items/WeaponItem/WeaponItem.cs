using Entities;
using UnityEngine;
using WeaponLogic;

namespace Inventory.Items.WeaponItem
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 1)]
    public class WeaponItem : Item
    {
        public int Damage;
        public float AttackDelay;
        public WeaponType Type;

        public override void Equip()
        {
            Entities.Entities.Player.Data.Weapon = this;
        }

        public Weapon CreateWeapon(Entity owner)
        {
            switch (Type)
            {
                case WeaponType.Melee:
                    return new MeleeWeapon(this);
                case WeaponType.Range:
                    return new RangeWeapon(this, owner);
            }

            return null;
        }
    }
}