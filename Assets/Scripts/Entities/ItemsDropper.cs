using System;
using Inventory.Items;
using Items;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class ItemsDropper
    {
        public event Action<ItemSo> ItemDropped;
        public ItemSo[] Items;
        
        private Vector3 _ownerPosition;
        
        public void Init(Vector3 ownerPosition)
        {
            _ownerPosition = ownerPosition;
        }
        
        public void Drop()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (RandomChance.Random(Items[i].DropChance))
                {
                    DroppedItemSpawner.Instance.SpawnItem(Items[i], _ownerPosition);
                    ItemDropped?.Invoke(Items[i]);
                    return;
                }
            }
        }
    }
}