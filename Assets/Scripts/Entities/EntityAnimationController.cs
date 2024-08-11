using UnityEngine;
using Weapons;

namespace Entities
{
    [System.Serializable]
    public class EntityAnimationController
    {
        [SerializeField] private Animator animator;
        
        private AttackLogic _attackLogic;

        public EntityAnimationController(AttackLogic attackLogic)
        {
        }
        
        public void Enter(AttackLogic attackLogic)
        {
            _attackLogic = attackLogic;

            _attackLogic.Attacked += SetAttackAnimation;
            _attackLogic.StartWaitingAttackDelay += SetIdleAnimation;
        }

        public void Exit()
        {
            _attackLogic.Attacked -= SetAttackAnimation;
            _attackLogic.StartWaitingAttackDelay -= SetIdleAnimation;
        }

        private void SetIdleAnimation()
        {
            animator.SetTrigger("Idle");
        }

        private void SetAttackAnimation(WeaponType type)
        {
            if (type == WeaponType.Melee)
            {
                animator.SetTrigger("MeleeAttack");
                return;
            }
            
            animator.SetTrigger("RangeAttack");
        }
    }
}