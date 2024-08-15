using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "Entities/Player", order = 1)]
    public class PlayerSo : EntityDataSo
    {
        public Inventory.Inventory Inventory;
        public PlayerExp PlayerExp;
    }
}