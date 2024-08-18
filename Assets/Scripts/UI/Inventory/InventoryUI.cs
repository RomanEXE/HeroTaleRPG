using Inventory;
using Inventory.Items;
using Items;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public static InventoryUI Instance { get; private set; }
        
        [SerializeField] private InventoryCell[] cells;
        [SerializeField] private ItemInfoShowing infoShowing;
        [SerializeField] private PlayerStatsUI statsUI;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void AddItem(ItemSo item)
        {
            infoShowing.Hide();
            
            InventoryCell cell = GetFreeCell();

            if (cell != null)
            {
                cell.SetItem(item);
            }
        }

        public void RemoveItem(ItemSo item)
        {
            infoShowing.Hide();
            
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].Item != null && cells[i].Item == item)
                {
                    cells[i].RemoveItem();
                    return;
                }
            }
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            infoShowing.Hide();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            infoShowing.Hide();
        }
        
        private InventoryCell GetFreeCell()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].Item == null)
                {
                    return cells[i];
                }
            }
            return null;
        }
    }
}