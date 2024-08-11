using UnityEngine;
using UnityEngine.UI;

namespace Entities
{
    [CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/Entity", order = 1)]
    public class EntityDataSo : ScriptableObject
    {
        public int MaxHp;
        public int CurrentHp;
        public int Damage;
        public int Armor;
        public Image Image;
    }
}