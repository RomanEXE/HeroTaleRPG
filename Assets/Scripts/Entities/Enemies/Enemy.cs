using System;
using DefaultNamespace;

namespace Entities.Enemies
{
    public class Enemy : Entity
    {
        public event Action EnemyDied;

        protected override void Die()
        {
            base.Die();
            EnemyDied?.Invoke();
            
            gameObject.SetActive(false);
        }

        protected override void OnFightStateStarted()
        {
            gameObject.SetActive(true);
            AttackLogic.Target = Fight.Player;
        }
    }
}