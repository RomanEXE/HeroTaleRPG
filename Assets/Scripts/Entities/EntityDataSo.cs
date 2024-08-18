using System.Collections.Generic;
using Inventory.Items;
using Inventory.Items.WeaponItem;
using Items;
using Sirenix.OdinInspector;
using UnityEditor.Animations;
using UnityEngine;

namespace Entities
{
    public class EntityDataSo : SerializedScriptableObject
    {
        public Dictionary<StatType, float> Stats;
        public float CurrentHp;
        [Range(0, 100)] public int SpawnChance;
        public WeaponItemSo Weapon;
        public AnimatorController Animator;
    }
}