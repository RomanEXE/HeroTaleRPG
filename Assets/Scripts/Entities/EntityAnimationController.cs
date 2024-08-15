using GameStates;
using Inventory.Items.WeaponItem;
using UnityEditor.Animations;
using UnityEngine;

namespace Entities
{
    [System.Serializable]
    public class EntityAnimationController
    {
        [SerializeField] private Animator animator;
        
        private Entity _owner;

        public EntityAnimationController(Entity owner)
        {
        }
        
        public void Enter(AnimatorController animatorController)
        {
            animator.runtimeAnimatorController = animatorController;
            GameState.IdleState.IdleStateStarted += SetIdleAnimation;
        }

        public void Exit()
        {
            GameState.IdleState.IdleStateStarted -= SetIdleAnimation;
        }

        public void SetIdleAnimation()
        {
            animator.SetTrigger("Idle");
        }

        public void SetAttackAnimation(WeaponType type)
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