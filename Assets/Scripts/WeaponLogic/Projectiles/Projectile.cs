using Entities;
using UnityEngine;

namespace WeaponLogic.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public Entity Target;
        [SerializeField] private float speed;
        
        private void Update()
        {
            Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
    }
}