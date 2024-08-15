using Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventoryCell : MonoBehaviour
    {
        public Item Item => item;

        [SerializeField] private Image image;
        [SerializeField] private Item item;

        public void SetItem(Item newItem)
        {
            item = newItem;
            image.sprite = item.Icon;
            gameObject.SetActive(true);
        }

        public void Remove()
        {
            item = null;
            gameObject.SetActive(false);
        }
    }
}