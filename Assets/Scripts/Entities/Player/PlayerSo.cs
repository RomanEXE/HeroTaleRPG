using System.Collections.Generic;
using Inventory;
using Inventory.Items;
using Items;
using UI.Inventory;
using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "Entities/Player", order = 1)]
    public class PlayerSo : EntityDataSo
    {
        public PlayerExp PlayerExp;
        public List<ItemSo> InventoryItems;
        public Dictionary<EquippedItemsSlots, ItemSo> Slots;
    }
}