using System;
using GameStates;
using Inventory.Items;
using Inventory.Items.WeaponItem;
using Items;
using States.EntityStateMachine;
using UI;
using UnityEngine;
using WeaponLogic;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        public event Action SwitchedWeapon;
        
        public Weapon Weapon { get; private set; }
        [field: SerializeField] public EntityUI UI { get; private set; }
        [field: SerializeField] public EntityAnimationController Animator { get; private set; }
        
        [SerializeField] private WeaponItemSo weaponData;
        [SerializeField] protected SpriteRenderer visual;
        
        private EntityStateMachine _stateMachine;
        
        
        public WeaponItemSo Range;

        
        public virtual void Init()
        {
            Animator?.Enter(GetData().Animator);
            Weapon = weaponData.CreateWeapon(this);
            _stateMachine = new EntityStateMachine(this, GetTarget());
            UI.Init(_stateMachine);
            
            GameState.FightState.FightStarted += OnFightStateStarted;
            GameState.IdleState.IdleStateStarted += OnIdleStateStarted;
        }
        
        public void ApplyDamage(float damage)
        {
            GetData().CurrentHp -= damage;
            UI.HpBar.ChangeValue(GetData().CurrentHp, GetData().Stats[StatType.MaxHp]);

            if (GetData().CurrentHp <= 0)
            {
                Die();
            }
        }
        
        public void SwitchWeapon()
        {
            SwitchedWeapon?.Invoke();
            Weapon = Range.CreateWeapon(this);
        }

        #region Virtual

        protected virtual Entity GetTarget()
        {
            return null;
        }
        
        protected virtual void Die()
        {
            Animator?.Exit();
        }
        
        protected virtual void OnFightStateStarted()
        {
            UI.HpBar.ChangeValue(GetData().CurrentHp, GetData().Stats[StatType.MaxHp]);
        }
        
        protected virtual void OnIdleStateStarted()
        {
            if (UI == null || UI.HpBar == null)
            {
                return;
            }
            UI.HpBar.ChangeValue(GetData().CurrentHp, GetData().Stats[StatType.MaxHp]);
        }

        public virtual EntityDataSo GetData()
        {
            return null;
        }

        #endregion
    }
}