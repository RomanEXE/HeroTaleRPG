using UnityEngine;

namespace Entities.Player
{
    public class PlayerExp : MonoBehaviour
    {
        [Header("Exp")]
        [SerializeField] private AnimationCurve expCurve;
        [SerializeField] private int currentExp;
        [SerializeField] private int requiredExp;
        [SerializeField] private int maxRequiredExp;
        
        [Header("Level")]
        [SerializeField] private int level;
        [SerializeField] private int maxLevel;

        public void IncreaseExp(int value)
        {
            if (!CanAddExp(value))
            {
                return;
            }
            
            currentExp += value;
            
            if (currentExp >= requiredExp)
            {
                while (currentExp >= requiredExp)
                {
                    currentExp -= requiredExp;
                    LevelUp();
                }
            }
        }

        private bool CanAddExp(int value)
        {
            if (level == maxLevel)
            {
                if (currentExp + value >= maxRequiredExp)
                {
                    currentExp = maxRequiredExp;
                }

                return false;
            }

            return true;
        }
        
        private void LevelUp()
        {
            level++;
        }

        public void CalculateRequiredExp()
        {
            requiredExp = Mathf.RoundToInt(expCurve.Evaluate(Mathf.InverseLerp(0, maxLevel, level)) * maxRequiredExp);
        }

        private void UpdateUI()
        {
            
        }
    }
}