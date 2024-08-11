using UnityEngine;

namespace Entities.Enemies
{
    public class EnemySo : ScriptableObject
    {
        [SerializeField] private int maxHp;
        [SerializeField] private int currentHp;
        [SerializeField] private int armor;
        [SerializeField] private int damage;
    }
}