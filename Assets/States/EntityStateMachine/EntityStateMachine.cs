using System;
using System.Collections.Generic;
using DefaultNamespace;
using Entities;
using GameStates;
using Inventory.Items.WeaponItem;
using UnityEngine;

namespace States.EntityStateMachine
{
    public class EntityStateMachine : StateMachineBasic<EntityStates>
    {
        public Entity Owner { get; private set; }
        public Entity Target { get; private set; }
        public Timer AttackPreparingTimer;

        public EntityStateMachine(Entity owner, Entity target) : base()
        {
            Owner = owner;
            Target = target;
            
            States = new Dictionary<EntityStates, IState>()
            {
                { EntityStates.IdleState, new IdleState(this) },
                { EntityStates.AttackState, new AttackState(this) },
                { EntityStates.PrepareForAttack, new PrepareForAttackState(this) },
                { EntityStates.SwitchingWeapon, new SwitchingWeaponState(this) }
            };
            
            GameState.IdleState.IdleStateStarted += SetIdleState;
        }

        private void SetIdleState()
        {
            ChangeState(EntityStates.IdleState);
        }
    }
}