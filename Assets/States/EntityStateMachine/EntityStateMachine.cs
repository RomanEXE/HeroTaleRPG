using System;
using System.Collections.Generic;
using Entities;
using GameStates;

namespace States.EntityStateMachine
{
    public class EntityStateMachine : StateMachineBasic<EntityStates>
    {
        public event Action<EntityStates> StateChanged; 
        
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

        public override void ChangeState(EntityStates state)
        {
            base.ChangeState(state);
            StateChanged?.Invoke(state);
        }
    }
}