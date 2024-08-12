using DefaultNamespace;
using GameStates;
using UnityEngine;

namespace States.EntityStateMachine
{
    public class PrepareForAttackState : IState
    {
        private EntityStateMachine _entityStateMachine;
        private Timer _timer;
        
        public PrepareForAttackState(EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
        }
        
        public void Enter()
        {
            if (GameState.GetCurrentState() == GameState.IdleState)
            {
                _entityStateMachine.ChangeState(EntityStates.IdleState);
                return;
            }
            _entityStateMachine.Owner.Animator.SetIdleAnimation();
            PrepareForAttack();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _timer?.Cancel();
            _timer = null;
        }

        private void PrepareForAttack()
        {
            _timer = Timer.Register(_entityStateMachine.Owner, _entityStateMachine.Owner.Data.PreparingForAttack, OnWaitAttackDelayComplete);
        }

        private void OnWaitAttackDelayComplete()
        {
            _entityStateMachine.ChangeState(EntityStates.AttackState);
        }
    }
}