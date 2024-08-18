using Inventory;
using Inventory.Items;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventoryCell : MonoBehaviour
    {
        public ItemSo Item => _item;

        [SerializeField] private Image image;
        [SerializeField] private Button button;
        
        private ItemSo _item;

        private void OnEnable()
        {
            if (button == null)
            {
                return;
            }
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        private void OnButtonClicked()
        {
            if (_item == null)
            {
                return;
            }
            
            ItemInfoShowing.Instance.DisplayInfo(_item);
        }
        
        public void SetItem(ItemSo newItem)
        {
            _item = newItem;
            image.sprite = _item.Icon;
            gameObject.SetActive(true);
        }

        public void RemoveItem()
        {
            _item = null;
            gameObject.SetActive(false);
        }
    }
}