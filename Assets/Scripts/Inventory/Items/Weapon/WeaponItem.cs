using DefaultNamespace.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Items.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 1)]
    public class WeaponItem : Item
    {
        public int Damage;
        public float AttackDelay;
        public WeaponType Type;
        public Image Image;
    }
}