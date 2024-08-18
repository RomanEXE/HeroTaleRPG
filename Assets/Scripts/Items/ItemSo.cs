using System.Collections.Generic;
using Inventory;
using Inventory.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Items
{
    public class ItemSo : SerializedScriptableObject
    {
        public string Name;
        [Range(0, 100)] public int DropChance;
        public Sprite Icon;
        public ItemUsageType UsageType;
        //[ShowIf("UsageType", ItemUsageType.Equipping)]
        //public ItemStats Stats;
        [ShowIf("UsageType", ItemUsageType.Equipping)]
        public EquippedItemsSlots Slot;
        [ShowIf("UsageType", ItemUsageType.Equipping)]
        public Dictionary<StatType, float> Stats;

        public virtual void Equip()
        {
            
        }

        public virtual void Remove()
        {
            
        }

        public virtual void GetInfo()
        {
            
        }
    }
}