using DefaultNamespace;
using GameStates;
using UI;

namespace States.EntityStateMachine
{
    public class AttackState : IState
    {
        private EntityStateMachine _entityStateMachine;
        private bool _isOwnerSwitchedWeapon;
        
        public AttackState(EntityStateMachine stateMachine)
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
                StateText.Instance.ChangeText("Attack");
            }

            _entityStateMachine.Owner.SwitchedWeapon += OnOwnerSwitchedWeapon;
            
            WaitAttackRate();
        }

        private void OnOwnerSwitchedWeapon()
        {
            _isOwnerSwitchedWeapon = true;
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            _entityStateMachine.Owner.SwitchedWeapon -= OnOwnerSwitchedWeapon;
        }
        
        private void WaitAttackRate()
        {
            _entityStateMachine.Owner.Weapon.AttackRateEnded += Attack;
            _entityStateMachine.Owner.Animator.SetAttackAnimation(_entityStateMachine.Owner.Weapon.Data.Type);
            _entityStateMachine.Owner.Weapon.TryWaitAttackRate(_entityStateMachine.Owner);
        }
        
        private void Attack()
        {
            _entityStateMachine.Owner.Weapon.AttackRateEnded -= Attack;
            _entityStateMachine.Owner.Weapon.Attack(_entityStateMachine.Target);
            
            SelectNextState();
        }

        private void SelectNextState()
        {
            if (_isOwnerSwitchedWeapon)
            {
                _entityStateMachine.ChangeState(EntityStates.SwitchingWeapon);
                _isOwnerSwitchedWeapon = false;
                return;
            }
            
            _entityStateMachine.ChangeState(EntityStates.PrepareForAttack);
        }
    }
}