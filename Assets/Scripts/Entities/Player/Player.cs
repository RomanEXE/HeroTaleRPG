using System;
using DefaultNamespace;

namespace Entities.Player
{
    public class Player : Entity
    {
        public event Action PlayerDied;
        
        protected override void Die()
        {
            base.Die();
            
            PlayerDied?.Invoke();
        }

        protected override void OnFightStateStarted()
        {
            AttackLogic.Target = Fight.Enemy;
        }

        public void Heal()
        {
            Data.CurrentHp = Data.MaxHp;
        }
    }
}