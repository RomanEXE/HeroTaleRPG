using DefaultNamespace;
using GameStates;
using UI;

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
            
            if (_entityStateMachine.Owner == Fight.Player)
            {
                StateText.Instance.ChangeText("Prepare");
            }
            
            _entityStateMachine.Owner.SwitchedWeapon += OnOwnerSwitchedWeapon;
            _entityStateMachine.Owner.Animator.SetIdleAnimation();
            
            PrepareForAttack();
        }

        private void OnOwnerSwitchedWeapon()
        {
            _entityStateMachine.ChangeState(EntityStates.SwitchingWeapon);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _entityStateMachine.Owner.SwitchedWeapon -= OnOwnerSwitchedWeapon;
            _entityStateMachine.AttackPreparingTimer?.Pause();
            //_timer?.Cancel();
            //_timer = null;
        }

        private void PrepareForAttack()
        {
            if (_entityStateMachine.AttackPreparingTimer != null && _entityStateMachine.AttackPreparingTimer.isPaused)
            {
                _entityStateMachine.AttackPreparingTimer.Resume();
                return;
            }
            
            _entityStateMachine.AttackPreparingTimer = Timer.Register(_entityStateMachine.Owner, _entityStateMachine.Owner.GetData().PreparingForAttack, OnWaitAttackDelayComplete);
        }

        private void OnWaitAttackDelayComplete()
        {
            _entityStateMachine.AttackPreparingTimer?.Cancel();
            _entityStateMachine.AttackPreparingTimer = null;
            
            _entityStateMachine.ChangeState(EntityStates.AttackState);
        }
    }
}