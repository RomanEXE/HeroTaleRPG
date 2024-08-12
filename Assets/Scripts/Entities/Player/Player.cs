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

        public void Heal()
        {
            Data.CurrentHp = Data.MaxHp;
        }

        protected override Entity GetTarget()
        {
            return Fight.Enemy;
        }
    }
}