using System;
using DefaultNamespace;
using UnityEngine;

namespace Entities.Enemies
{
    public class Enemy : Entity
    {
        public event Action EnemyDied;
        public EnemySo Data;
        [SerializeField] private ItemsDropper _dropper;

        public override void Init()
        {
            base.Init();
        }

        protected override void Die()
        {
            base.Die();
            EnemyDied?.Invoke();
            Data.CurrentHp = Data.MaxHp;
            visual.gameObject.SetActive(false);
        }

        protected override void OnFightStateStarted()
        {
            visual.gameObject.SetActive(true);
            //AttackLogic.Target = Fight.Player;
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