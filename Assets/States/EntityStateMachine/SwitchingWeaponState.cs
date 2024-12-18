using Inventory.Items;
using Items;
using UI;

namespace States.EntityStateMachine
{
    public class SwitchingWeaponState : IState
    {
        private EntityStateMachine _entityStateMachine;
        private Timer _timer;
        
        public SwitchingWeaponState(EntityStateMachine stateMachine)
        {
            _entityStateMachine = stateMachine;
        }
        
        public void Enter()
        {
            if (_entityStateMachine.Owner == Entities.Entities.Enemy)
            {
                StateText.Instance.ChangeText("Switching");
            }
            
            if (_entityStateMachine.AttackPreparingTimer != null && _entityStateMachine.AttackPreparingTimer.isPaused)
            {
                _entityStateMachine.AttackPreparingTimer.Pause();
            }
            
            _entityStateMachine.Owner.Animator.SetIdleAnimation();
            _timer = Timer.Register(_entityStateMachine.Owner, _entityStateMachine.Owner.GetData().Stats[StatType.ChangingWeaponTime], SelectNextState);
        }

        private void SelectNextState()
        {
            //_entityStateMachine.Owner.Weapon.ChangeWeapon();

            if (_entityStateMachine.AttackPreparingTimer != null && _entityStateMachine.AttackPreparingTimer.isPaused)
            {
                _entityStateMachine.ChangeState(EntityStates.PrepareForAttack);
                return;
            }
            
            _entityStateMachine.ChangeState(EntityStates.AttackState);
        }

        public void Exit()
        {
            _timer?.Cancel();
        }
    }
}