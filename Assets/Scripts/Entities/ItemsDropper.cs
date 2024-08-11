using System.Collections.Generic;
using DefaultNamespace.Inventory;
using Sirenix.OdinInspector;

namespace Entities
{
    [System.Serializable]
    public class ItemsDropper : SerializedMonoBehaviour
    {
        [DictionaryDrawerSettings(KeyLabel = "Предмет", ValueLabel = "Шанс выпадения")]
        public Dictionary<Item, int> Items = new Dictionary<Item, int>();

        public void Drop()
        {
            
        }
    }
}