using UnityEditor.Animations;
using UnityEngine;

namespace Entities
{
    public class EntityDataSo : ScriptableObject
    {
        public int MaxHp;
        public int CurrentHp;
        public int Armor;
        public float PreparingForAttack;
        public float ChangingWeaponTime;
        [Range(0, 100)] public int SpawnChance;
        public AnimatorController Animator;
    }
}