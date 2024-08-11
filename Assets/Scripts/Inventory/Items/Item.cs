using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Inventory
{
    public class Item : ScriptableObject
    {
        public int Name;
        public Image Icon;

        public virtual void Equip()
        {
            
        }

        public virtual void Remove()
        {
            
        }
    }
}