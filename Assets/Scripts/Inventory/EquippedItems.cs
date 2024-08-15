using System.Collections.Generic;
using Inventory.Items;
using Inventory.Items.Armor;
using Inventory.Items.WeaponItem;
using Sirenix.OdinInspector;
using UI.Inventory;

namespace Inventory
{
    public class EquippedItems : SerializedBehaviour
    {
        public ArmorItem Helmet;
        public ArmorItem Chest;
        public ArmorItem Boots;
        public WeaponItem Weapon;

        [DictionaryDrawerSettings]
        public Dictionary<EquippedItemsSlots, InventoryCell> Slots;
        
        public void EquipItem(EquippedItemsSlots slot, Item item)
        {
            Entities.Entities.Player.Data.Inventory.RemoveItem(item);
            Entities.Entities.Player.Data.Inventory.AddItem(Slots[slot].Item);
            Slots[slot].SetItem(item);
            
            item.Equip();
            Entities.Entities.Player.SwitchWeapon();
        }
    }
}