using DefaultNamespace;
using GameStates;
using UnityEngine;

namespace States.EntityStateMachine
{
    public class IdleState : IState
    {
        private EntityStateMachine _entityStateMachine;
        
        public IdleState(EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _entityStateMachine.Owner.Animator.SetIdleAnimation();
            GameState.FightState.FightStarted += OnFightStarted;
        }

        private void OnFightStarted()
        {
            _entityStateMachine.ChangeState(EntityStates.PrepareForAttack);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            GameState.FightState.FightStarted -= OnFightStarted;
        }
    }
}