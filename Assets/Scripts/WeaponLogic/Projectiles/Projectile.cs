using DG.Tweening;
using Entities;
using Lean.Pool;
using UnityEngine;

namespace WeaponLogic.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public Entity Target;
        public int Damage;
        [SerializeField] private float speed;

        public void Move()
        {
            transform.DOMove(Target.transform.position, speed)
                .SetSpeedBased(true)
                .SetLink(gameObject)
                .OnComplete(OnMovedToTarget);
        }

        private void OnMovedToTarget()
        {
            LeanPool.Despawn(this);
            Target.ApplyDamage(Damage);
        }

        private void Update()
        {
            //Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
    }
}