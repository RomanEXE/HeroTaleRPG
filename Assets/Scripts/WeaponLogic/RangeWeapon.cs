using Entities;
using Inventory.Items;
using Inventory.Items.WeaponItem;
using Items;
using WeaponLogic.Projectiles;

namespace WeaponLogic
{
    public class RangeWeapon : Weapon
    {
        public RangeWeapon(WeaponItemSo data, Entity owner) : base(data, owner)
        {
            
        }

        public override void Attack(Entity target)
        {
            ProjectileSpawner.Instance.Spawn(target, Owner.transform.position, Data.Damage + Owner.GetData().Stats[StatType.Power]);
        }
    }
}