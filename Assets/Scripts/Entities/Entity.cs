using GameStates;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        public EntityData Data;
        public AttackLogic AttackLogic { get; private set; }
        
        public int Damage { get; private set; }
        
        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void OnIdleStateStarted()
        {
            AttackLogic.StopAttack();
        }

        protected virtual void OnFightStarted()
        {
            
        }
        
        public void Init(WeaponSo weaponData)
        {
            AttackLogic = new AttackLogic(weaponData, this);
        }

        public void Init()
        {
            AttackLogic = new AttackLogic(null, this);
            GameState.FightState.FightStarted += OnFightStarted;
            GameState.IdleState.IdleStateStarted += OnIdleStateStarted;
        }
        
        public void ApplyDamage(int damage)
        {
            Data.CurrentHp -= damage;

            if (Data.CurrentHp <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
        
        }
    }
}