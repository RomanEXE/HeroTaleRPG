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
            
            visual.gameObject.SetActive(false);
        }

        protected override void OnFightStateStarted()
        {
            visual.gameObject.SetActive(true);
            AttackLogic.Target = Fight.Player;
        }

        protected override void OnIdleStateStarted()
        {
            visual.gameObject.SetActive(false);
        }
    }
}