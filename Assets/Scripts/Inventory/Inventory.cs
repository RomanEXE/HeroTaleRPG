using System.Collections.Generic;
using Inventory.Items;

namespace Inventory
{
    public class Inventory
    {
        public int MaxItems;
        public List<Item> Items;

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}