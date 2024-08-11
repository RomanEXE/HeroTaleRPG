using DefaultNamespace;

namespace Entities.Player
{
    public class Player : Entity
    {
        protected override void OnFightStateStarted()
        {
            AttackLogic.Target = Fight.Enemy;
        }

        public void Heal()
        {
            Data.CurrentHp = Data.MaxHp;
        }
    }
}