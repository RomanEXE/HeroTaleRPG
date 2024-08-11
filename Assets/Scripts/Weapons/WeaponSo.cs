using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
    public class WeaponSo : ScriptableObject
    {
        public int Damage;
        public float AttackDelay;
        public WeaponType Type;
        public Image Image;
    }
}