using UnityEngine;

namespace Inventory.Items
{
    public class Item : ScriptableObject
    {
        public int Name;
        [Range(0, 100)] public int DropChance;
        public Sprite Icon;

        public virtual void Equip()
        {
            
        }

        public virtual void Remove()
        {
            
        }
    }
}