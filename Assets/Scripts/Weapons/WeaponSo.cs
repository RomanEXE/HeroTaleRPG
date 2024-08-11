using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
    public class WeaponSo : ScriptableObject
    {
        public int Damage;
        public float AttackDelay;
        public WeaponType Type;
        public Image Image;
    }
}