using UnityEditor.Animations;
using UnityEngine;

namespace Entities
{
    public class EntityDataSo : ScriptableObject
    {
        public int MaxHp;
        public int CurrentHp;
        public int Damage;
        public int Armor;
        public float PreparingForAttack;
        public float ChangingWeaponTime;
        public AnimatorController Animator;
    }
}