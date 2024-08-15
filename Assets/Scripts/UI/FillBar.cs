using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FillBar : MonoBehaviour
    {
        [SerializeField] private Image fillBar;
        [SerializeField] private TextMeshProUGUI tmp;
        
        public void ChangeValue(float value, float maxValue)
        {
            fillBar.fillAmount = value / maxValue;
            tmp.text = $"{value}/{maxValue}";
        }
    }
}