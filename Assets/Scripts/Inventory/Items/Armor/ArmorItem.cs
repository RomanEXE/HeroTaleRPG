using DefaultNamespace;
using DefaultNamespace.Inventory;
using UnityEngine;

namespace Inventory.Items.Armor
{
    [CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 1)]
    public class ArmorItem : Item
    {
        public ArmorType Type;
        public int Hp;
        public int Armor;

        public override void Equip()
        {
            Fight.Player.Data.MaxHp += Hp;
            Fight.Player.Data.Armor += Armor;
        }

        public override void Remove()
        {
            Fight.Player.Data.MaxHp -= Hp;
            Fight.Player.Data.Armor -= Armor;
        }
    }
}