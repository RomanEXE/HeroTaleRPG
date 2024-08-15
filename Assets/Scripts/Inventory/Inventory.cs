using Inventory.Items;
using UI.Inventory;
using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private InventoryCell[] items;
        [SerializeField] private int maxItems;

        [SerializeField] private InventoryUI ui;

        public void Init()
        {
            Entities.Entities.Enemy.Data.ItemsDropper.ItemDropped += AddItem;
        }
        
        public void AddItem(Item item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Item != null)
                {
                    items[i].SetItem(item);
                }
            }
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Item == item)
                {
                    items[i].Remove();
                }
            }
        }
    }
}