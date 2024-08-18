using GameStates;
using Inventory.Items;
using Items;
using UI;

namespace States.EntityStateMachine
{
    public class PrepareForAttackState : IState
    {
        private EntityStateMachine _entityStateMachine;
        
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
            
            if (_entityStateMachine.Owner == Entities.Entities.Enemy)
            {
                StateText.Instance.ChangeText("Prepare");
            }
            
            _entityStateMachine.Owner.SwitchedWeapon += OnWeaponSwitched;
            _entityStateMachine.Owner.Animator.SetIdleAnimation();
            
            PrepareForAttack();
        }

        private void OnWeaponSwitched()
        {
            _entityStateMachine.ChangeState(EntityStates.SwitchingWeapon);
        }

        public void Exit()
        {
            _entityStateMachine.Owner.SwitchedWeapon -= OnWeaponSwitched;
            _entityStateMachine.AttackPreparingTimer?.Pause();
        }

        private void PrepareForAttack()
        {
            if (_entityStateMachine.AttackPreparingTimer != null && _entityStateMachine.AttackPreparingTimer.isPaused)
            {
                _entityStateMachine.AttackPreparingTimer.Resume();
                return;
            }
            
            _entityStateMachine.AttackPreparingTimer = Timer.Register(_entityStateMachine.Owner, _entityStateMachine.Owner.GetData().Stats[StatType.PrepareForAttack], OnWaitAttackDelayComplete);
        }

        private void OnWaitAttackDelayComplete()
        {
            _entityStateMachine.AttackPreparingTimer?.Cancel();
            
            _entityStateMachine.ChangeState(EntityStates.AttackState);
        }
    }
}