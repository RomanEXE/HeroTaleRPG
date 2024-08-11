using DefaultNamespace;

namespace Entities.Enemies
{
    public class Enemy : Entity
    {
        protected override void OnFightStarted()
        {
            AttackLogic.StartAttack(Fight.Player);
        }
    }
}