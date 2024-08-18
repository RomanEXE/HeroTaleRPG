using System.Collections.Generic;
using Items;
using Sirenix.OdinInspector;
using UI.Inventory;
using UnityEngine;

namespace Inventory
{
    public class EquippedItems : SerializedMonoBehaviour
    {
        [DictionaryDrawerSettings]
        public Dictionary<EquippedItemsSlots, InventoryCell> Slots;

        [SerializeField] private InventoryUI ui;

        private void Start()
        {
            foreach (var slot in Entities.Entities.Player.Data.Slots)
            {
                if (slot.Value != null)
                {
                    Slots[slot.Key].SetItem(slot.Value);
                }
            }
        }

        public void EquipItem(EquippedItemsSlots slot, ItemSo item)
        {
            if (Slots[slot].Item == item)
            {
                return;
            }
            
            //ui.RemoveItem(item);
            Entities.Entities.Player.Inventory.RemoveItem(item);
            
            if (Slots[slot].Item != null)
            {
                RemoveOldItem(Slots[slot].Item);
                //Slots[slot].Item.Remove();
                //ui.AddItem(Slots[slot].Item);
            }
            
            Slots[slot].SetItem(item);
            Entities.Entities.Player.Data.Slots[slot] = item;
            
            item.Equip();
            Entities.Entities.Player.SwitchWeapon();
        }

        private void RemoveOldItem(ItemSo oldItem)
        {
            oldItem.Remove();
            Entities.Entities.Player.Inventory.AddItem(oldItem);
        }
    }
}