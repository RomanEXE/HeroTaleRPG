using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image fillBar;
        [SerializeField] private TextMeshProUGUI hpTMP;

        private float _maxValue;

        public void Init(float maxValue)
        {
            _maxValue = maxValue;
        }
        
        public void ChangeValue(float value)
        {
            fillBar.fillAmount = value / _maxValue;
            hpTMP.text = $"{value}/{_maxValue}";
        }
    }
}