using DefaultNamespace;
using Weapons;

namespace Entities.Player
{
    public class Player : Entity
    {
        public void ChangeWeapon(WeaponSo weaponData)
        {
            AttackLogic.ChangeWeapon(weaponData);
        }

        protected override void OnFightStarted()
        {
            //TODO: Сначала подождать начало атаки
            
            AttackLogic.StartAttack(Fight.Enemy);
        }
    }
}