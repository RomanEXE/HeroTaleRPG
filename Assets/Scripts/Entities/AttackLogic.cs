using System;
using DefaultNamespace;
using GameStates;
using Weapons;

namespace Entities
{
    public class AttackLogic
    {
        public event Action<WeaponType> Attacked;
        public event Action StartWaitingAttackDelay;
        
        private Weapon _weapon;
        private Entity _owner;
        private Entity _target;

        public AttackLogic(WeaponSo weaponData, Entity owner)
        {
            _weapon = new Weapon(weaponData);
            _owner = owner;
        }

        public void Enter()
        {
            GameState.FightState.FightStarted += WaitPreparingAttackDelay;
            GameState.IdleState.IdleStateStarted += StopAttack;
        }

        public void Exit()
        {
            GameState.FightState.FightStarted -= WaitPreparingAttackDelay;
            GameState.IdleState.IdleStateStarted -= StopAttack;
        }
        
        private void WaitPreparingAttackDelay()
        {
            Timer.Register(_owner, _owner.Data.PreparingForAttack, OnWaitAttackDelayComplete);
        }

        private void OnWaitAttackDelayComplete()
        {
            StartAttack(Fight.Enemy);
        }

        private void StartAttack(Entity target)
        {
            _target = target;
            
            bool canWaitAttackDelay = _weapon.TryWaitAttackRate(_owner);

            if (canWaitAttackDelay)
            {
                StartWaitingAttackDelay?.Invoke();
            }
            
            _weapon.AttackRateEnded += Attack;
        }

        protected virtual void Attack()
        {
            _weapon.AttackRateEnded -= Attack;
            Attacked?.Invoke(_weapon.Data.Type);
            _target.ApplyDamage(_weapon.Data.Damage);
            
            StartAttack(_target);
        }

        private void StopAttack()
        {
            _weapon.AttackRateEnded -= Attack;
            _weapon.StopAttackRate();
        }

        public void ChangeWeapon(WeaponSo data)
        {
            _weapon = new Weapon(data);
        }
    }
}