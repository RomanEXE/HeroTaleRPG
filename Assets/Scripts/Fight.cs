using Entities;
using Entities.Enemies;
using Entities.Player;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Fight
    {
        public static Player Player;
        public static Enemy Enemy;

        public static void Init()
        {
            Player = MonoBehaviour.FindObjectOfType<Player>();
            Enemy = MonoBehaviour.FindObjectOfType<Enemy>();
        }
    }
}