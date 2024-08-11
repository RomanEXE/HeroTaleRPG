using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
    public class WeaponSo : ScriptableObject
    {
        public int Damage;
        public float AttackRate;
        public WeaponType Type;
        public Image Image;
    }
}