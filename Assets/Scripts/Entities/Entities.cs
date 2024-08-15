using Entities.Enemies;
using UnityEngine;

namespace Entities
{
    public static class Entities
    {
        public static Player.Player Player;
        public static Enemy Enemy;

        public static void Init()
        {
            Player = MonoBehaviour.FindObjectOfType<Player.Player>();
            Enemy = MonoBehaviour.FindObjectOfType<Enemy>();
        }
    }
}