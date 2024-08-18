using System;
using Inventory.Items;
using Items;

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
            Data.CurrentHp = Data.Stats[StatType.MaxHp];
            visual.gameObject.SetActive(true);
            base.OnFightStateStarted();
        }

        protected override void OnIdleStateStarted()
        {
            base.OnIdleStateStarted();
            visual.gameObject.SetActive(false);
        }

        protected override Entity GetTarget()
        {
            return Entities.Player;
        }

        public override EntityDataSo GetData()
        {
            return Data;
        }
    }
}