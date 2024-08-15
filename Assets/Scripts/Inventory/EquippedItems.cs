using System.Collections.Generic;
using Inventory.Items;
using Inventory.Items.Armor;
using Inventory.Items.WeaponItem;

namespace Inventory
{
    public class EquippedItems
    {
        public ArmorItem Helmet;
        public ArmorItem Chest;
        public ArmorItem Boots;
        public WeaponItem Weapon;

        public Dictionary<EquippedItemsSlots, Item> Slots = new Dictionary<EquippedItemsSlots, Item>();

        public void Init()
        {
            Slots.Add(EquippedItemsSlots.Helmet, null);
            Slots.Add(EquippedItemsSlots.Chest, null);
            Slots.Add(EquippedItemsSlots.Boots, null);
            Slots.Add(EquippedItemsSlots.Weapon, null);
        }
        
        public void EquipItem(EquippedItemsSlots slot, Item item)
        {
            Slots[slot]?.Remove();
            Slots[slot] = item;
            
            item.Equip();
            Entities.Entities.Player.SwitchWeapon();
        }
    }
}