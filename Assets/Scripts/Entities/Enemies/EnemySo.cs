using UnityEngine;

namespace Entities.Enemies
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Entities/Enemy", order = 1)]
    public class EnemySo : EntityDataSo
    {
        public int ExpForKill;
    }
}