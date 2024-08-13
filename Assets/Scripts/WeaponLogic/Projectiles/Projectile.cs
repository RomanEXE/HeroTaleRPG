using DG.Tweening;
using Entities;
using UnityEngine;

namespace WeaponLogic.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public Entity Target;
        public int Damage;
        [SerializeField] private float speed;

        private void Start()
        {
            transform.DOMove(Target.transform.position, speed)
                .SetSpeedBased(true)
                .SetLink(gameObject)
                .OnComplete(OnMovedToTarget);
        }

        private void OnMovedToTarget()
        {
            Target.ApplyDamage(Damage);
        }

        private void Update()
        {
            //Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
    }
}