using GameStates;
using UnityEngine;
using Weapons;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        public AttackLogic AttackLogic { get; private set; }
        
        [SerializeField] protected int maxHp;
        [SerializeField] protected int currentHp;
        [SerializeField] protected int armor;
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
            currentHp -= damage;

            if (currentHp <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
        
        }
    }
}