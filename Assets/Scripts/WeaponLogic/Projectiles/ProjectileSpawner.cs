using Entities;
using Lean.Pool;
using UnityEngine;

namespace WeaponLogic.Projectiles
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private Projectile prefab;

        public static ProjectileSpawner Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Spawn(Entity target, Vector2 position, float damage)
        {
            Projectile spawnedProjectile = LeanPool.Spawn(prefab, position, Quaternion.identity);
            spawnedProjectile.Target = target;
            spawnedProjectile.Damage = damage;
            spawnedProjectile.Move();
        }
    }
}