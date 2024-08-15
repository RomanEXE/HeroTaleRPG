using System.Collections.Generic;
using Inventory.Items;
using UI.Inventory;
using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private List<Item> items;
        [SerializeField] private int maxItems;

        [SerializeField] private InventoryUI ui;

        public void Init()
        {
            Entities.Entities.Enemy.Data.ItemsDropper.ItemDropped += AddItem;
        }
        
        public void AddItem(Item item)
        {
            if (items.Count <= maxItems)
            {
                items.Add(item);
            }
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
    }
}