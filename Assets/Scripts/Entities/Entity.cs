using System;
using GameStates;
using Inventory.Items.WeaponItem;
using States.EntityStateMachine;
using UnityEngine;
using WeaponLogic;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        public event Action AttackEventInvoked;
        public Weapon Weapon { get; private set; }
        [field: SerializeField] public EntityAnimationController Animator { get; private set; }
        
        [SerializeField] private WeaponItem weaponData;
        [SerializeField] protected SpriteRenderer visual;
        
        private EntityStateMachine _stateMachine;
        
        public virtual void Init()
        {
            Animator?.Enter();
            Weapon = weaponData.CreateWeapon(this);
            _stateMachine = new EntityStateMachine(this, GetTarget());
            
            GameState.FightState.FightStarted += OnFightStateStarted;
            GameState.IdleState.IdleStateStarted += OnIdleStateStarted;
        }

        public void OnAttackEventInvoked()
        {
            
        }

        protected virtual Entity GetTarget()
        {
            return null;
        }
        
        public void ApplyDamage(int damage)
        {
            GetData().CurrentHp -= damage;

            if (GetData().CurrentHp <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Animator?.Exit();
        }
        
        protected virtual void OnFightStateStarted()
        {
            
        }
        
        protected virtual void OnIdleStateStarted()
        {
            
        }

        public virtual EntityDataSo GetData()
        {
            return null;
        }
    }
}