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
        
        public EntityData Data;
        //public AttackLogic AttackLogic { get; private set; }
        public Weapon Weapon { get; private set; }
        [field: SerializeField] public EntityAnimationController Animator { get; private set; }

        private EntityStateMachine _stateMachine;

        [SerializeField] private WeaponItem weaponData;
        [SerializeField] protected SpriteRenderer visual;
        
        public void Init(EntityDataSo data)
        {
            Data = new EntityData(data);
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
            Data.CurrentHp -= damage;

            if (Data.CurrentHp <= 0)
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
    }
}