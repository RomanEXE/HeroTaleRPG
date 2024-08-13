using Entities;
using Inventory.Items.WeaponItem;
using WeaponLogic.Projectiles;

namespace WeaponLogic
{
    public class RangeWeapon : Weapon
    {
        private Entity _owner;
        
        public RangeWeapon(WeaponItem data, Entity owner) : base(data)
        {
            _owner = owner;
        }

        public override void Attack(Entity target)
        {
            ProjectileSpawner.Instance.Spawn(target, _owner.transform.position, Data.Damage);
        }
    }
}