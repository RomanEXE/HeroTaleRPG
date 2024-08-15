using Entities;
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
            Entities.Entities.Player.Data.MaxHp += Hp;
            Entities.Entities.Player.Data.Armor += Armor;
        }

        public override void Remove()
        {
            Entities.Entities.Player.Data.MaxHp -= Hp;
            Entities.Entities.Player.Data.Armor -= Armor;
        }

        public override void GetInfo()
        {
            Stats.Value = Armor;
        }
    }
}