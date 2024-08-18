using System.Collections.Generic;
using Inventory.Items;
using Items;
using UI.Inventory;
using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private int maxItems;
        [SerializeField] private InventoryUI ui;
        
        private List<ItemSo> _items = new List<ItemSo>();
        
        public void Init()
        {
            Entities.Entities.Enemy.Data.ItemsDropper.ItemDropped += AddItem;
            _items = Entities.Entities.Player.Data.InventoryItems;

            for (int i = 0; i < _items.Count; i++)
            {
                ui.AddItem(_items[i]);
            }
        }
        
        public void AddItem(ItemSo itemSo)
        {
            if (_items.Count >= maxItems)
            {
                return;
            }
            
            _items.Add(itemSo);
            ui.AddItem(itemSo);
        }

        public void RemoveItem(ItemSo itemSo)
        {
            _items.Remove(itemSo);
            ui.RemoveItem(itemSo);
        }
    }
}