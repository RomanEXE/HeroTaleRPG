using System;
using DefaultNamespace;

namespace Entities.Enemies
{
    public class Enemy : Entity
    {
        public event Action EnemyDied;
        public EnemySo Data;
        
        public override void Init()
        {
            base.Init();
            Data.ItemsDropper.Init(transform.position);
        }

        protected override void Die()
        {
            base.Die();
            EnemyDied?.Invoke();
            Data.ItemsDropper.Drop();
        }

        protected override void OnFightStateStarted()
        {
            Data.CurrentHp = Data.MaxHp;
            visual.gameObject.SetActive(true);
        }

        protected override void OnIdleStateStarted()
        {
            visual.gameObject.SetActive(false);
        }

        protected override Entity GetTarget()
        {
            return Fight.Player;
        }

        public override EntityDataSo GetData()
        {
            return Data;
        }
    }
}