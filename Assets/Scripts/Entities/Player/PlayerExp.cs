using UI;
using UnityEngine;

namespace Entities.Player
{
    [System.Serializable]
    public class PlayerExp
    {
        [Header("Exp")]
        [SerializeField] private AnimationCurve expCurve;
        [SerializeField] private int currentExp;
        [SerializeField] private int requiredExp;
        [SerializeField] private int maxRequiredExp;
        
        [Header("Level")]
        [SerializeField] private int level;
        [SerializeField] private int maxLevel;

        [Header("UI")]
        [SerializeField] private FillBar expFillBar;

        public void Init()
        {
            Entities.Enemy.EnemyDied += OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            IncreaseExp(Entities.Enemy.Data.ExpForKill);
        }

        private void IncreaseExp(int value)
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
                    return false;
                }
            }

            return true;
        }
        
        private void LevelUp()
        {
            level++;
            Entities.Player.Data.MaxHp += 5;
            Entities.Player.Data.PreparingForAttack -= 0.1f;
            Entities.Player.Data.Armor++;
            
            CalculateRequiredExp();
        }

        private void CalculateRequiredExp()
        {
            requiredExp = Mathf.RoundToInt(expCurve.Evaluate(Mathf.InverseLerp(0, maxLevel, level)) * maxRequiredExp);
        }

        private void UpdateUI()
        {
            expFillBar.ChangeValue(currentExp, requiredExp);
        }
    }
}