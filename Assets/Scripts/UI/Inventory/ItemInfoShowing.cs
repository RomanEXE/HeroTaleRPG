using GameStates;
using Inventory;
using Inventory.Items;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class ItemInfoShowing : MonoBehaviour
    {
        public static ItemInfoShowing Instance { get; private set; }

        [SerializeField] private EquippedItems equippedItems;
        [SerializeField] private GameObject root;
        
        [Header("General")]
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI nameTMP;
        
        [Header("Stats")]
        [SerializeField] private Image statIcon;
        [SerializeField] private TextMeshProUGUI statValue;

        [Header("Interacting")]
        [SerializeField] private Button equipButton;

        private ItemSo _selectedItemSo;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void DisplayInfo(ItemSo item)
        {
            _selectedItemSo = item;
            
            icon.sprite = item.Icon;
            nameTMP.text = item.Name;

            //statIcon.sprite = item.Stats.Icon;
            //statValue.text = item.Stats.Value.ToString();

            if (item.UsageType == ItemUsageType.Equipping)
            {
                equipButton.gameObject.SetActive(true);
                equipButton.onClick.AddListener(EquipSelectedItem);
            }

            Show();
        }

        private void EquipSelectedItem()
        {
            equippedItems.EquipItem(_selectedItemSo.Slot, _selectedItemSo);
        }

        public void Show()
        {
            root.gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            root.SetActive(false);
            equipButton.onClick.RemoveAllListeners();
        }
    }
}