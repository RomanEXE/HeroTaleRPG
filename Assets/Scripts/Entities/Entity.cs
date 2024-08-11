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

        [SerializeField] private EntityAnimationController animator;
        [SerializeField] private WeaponSo weaponData;
        
        protected virtual void OnFightStateStarted()
        {
            
        }

        private void OnDisable()
        {

        }

        public void Init(EntityDataSo data)
        {
            AttackLogic = new AttackLogic(weaponData, this);
            AttackLogic.Enter();
            Data = new EntityData(data);
            animator?.Enter(AttackLogic);
            
            GameState.FightState.FightStarted += OnFightStateStarted;
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
            animator?.Exit();
            AttackLogic?.Exit();
        }
    }
}