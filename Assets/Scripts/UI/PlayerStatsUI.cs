using System.Collections.Generic;
using Inventory.Items;
using Items;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI armor;
        [SerializeField] private TextMeshProUGUI power;
        [SerializeField] private TextMeshProUGUI preparingForAttack;
        
        private Dictionary<StatType, float> _stats;
        
        public void Init(Dictionary<StatType, float> stats)
        {
            _stats = stats;
        }

        public void PrintStats()
        {
            armor.text = _stats[StatType.Armor].ToString();
            power.text = _stats[StatType.Power].ToString();
            preparingForAttack.text = _stats[StatType.PrepareForAttack].ToString();
        }
    }
}