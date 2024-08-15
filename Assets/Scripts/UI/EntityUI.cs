using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Entities;
using States.EntityStateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EntityUI : MonoBehaviour
    {
        public HpBar HpBar => hpBar;

        [SerializeField] private Entity owner;

        [Header("UI")]
        [SerializeField] private Image fillingImage;
        [SerializeField] private Image stateImage;
        [SerializeField] private HpBar hpBar;

        [Header("State Sprites")]
        [SerializeField] private Sprite attackState;
        [SerializeField] private Sprite idleState;

        private TweenerCore<float, float, FloatOptions> _fillAnimation;
        private EntityStateMachine _stateMachine;

        public void Init(EntityStateMachine stateMachine)
        {
            stateMachine.StateChanged += DrawStateImage;
            stateMachine.StateChanged += Fill;

            _stateMachine = stateMachine;
            
            hpBar.Init(owner.GetData().MaxHp);
        }

        private void Fill(EntityStates state)
        {
            _fillAnimation.Kill();
            fillingImage.fillAmount = 0;

            float time = 0f;

            stateImage.gameObject.SetActive(true);
            
            switch (state)
            {
                case EntityStates.AttackState:
                    StartFillAnimation(owner.Weapon.Data.AttackDelay, Color.white);
                    break;
                case EntityStates.PrepareForAttack:
                    fillingImage.fillAmount = _stateMachine.AttackPreparingTimer.GetTimeElapsed();
                    StartFillAnimation(_stateMachine.AttackPreparingTimer.GetTimeRemaining(), Color.yellow);
                    break;
                case EntityStates.SwitchingWeapon:
                    StartFillAnimation(owner.GetData().ChangingWeaponTime, Color.cyan);
                    break;
                default:
                    stateImage.gameObject.SetActive(false);
                    break;
            }
        }

        private void StartFillAnimation(float time, Color color)
        {
            fillingImage.color = color;
            
            _fillAnimation = fillingImage.DOFillAmount(1, time)
                .SetSpeedBased(false)
                .SetLink(owner.gameObject);
        }

        private void DrawStateImage(EntityStates state)
        {
            stateImage.gameObject.SetActive(true);

            switch (state)
            {
                case EntityStates.IdleState:
                    stateImage.gameObject.SetActive(false);
                    break;
                case EntityStates.AttackState:
                    stateImage.sprite = attackState;
                    break;
                default:
                    stateImage.sprite = idleState;
                    break;
            }
        }
    }
}