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
        [SerializeField] protected SpriteRenderer visual;

        public void Init(EntityDataSo data)
        {
            AttackLogic = new AttackLogic(weaponData, this);
            AttackLogic.Enter();
            Data = new EntityData(data);
            animator?.Enter(AttackLogic);
            
            GameState.FightState.FightStarted += OnFightStateStarted;
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
            animator?.Exit();
            AttackLogic?.Exit();
        }
        
        protected virtual void OnFightStateStarted()
        {
            
        }
        
        protected virtual void OnIdleStateStarted()
        {
            
        }
    }
}