using DefaultNamespace;
using GameStates;
using UnityEngine;

namespace States.EntityStateMachine
{
    public class AttackState : IState
    {
        private EntityStateMachine _entityStateMachine;
        
        public AttackState(EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
        }
        
        public void Enter()
        {
            if (_entityStateMachine.Owner == Fight.Enemy)
            {
                Debug.Log("attack");
            }

            if (GameState.GetCurrentState() == GameState.IdleState)
            {
                _entityStateMachine.ChangeState(EntityStates.IdleState);
                return;
            }
                
            _entityStateMachine.Owner.Animator.SetAttackAnimation(_entityStateMachine.Owner.Weapon.Data.Type);
            //_entityStateMachine.Owner.AttackEventInvoked += Attack;
            Attack();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _entityStateMachine.Owner.AttackEventInvoked -= Attack;
        }

        private void Attack()
        {
            _entityStateMachine.Owner.Weapon.Attack(_entityStateMachine.Target);
            
            _entityStateMachine.ChangeState(EntityStates.PrepareForAttack);
        }
    }
}