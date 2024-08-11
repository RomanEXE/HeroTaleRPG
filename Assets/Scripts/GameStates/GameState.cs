using States;
using UnityEngine;

namespace GameStates
{
    public class GameState : MonoBehaviour
    {
        public static GameFightState FightState { get; private set; } = new GameFightState();
        public static GameIdleState IdleState { get; private set; } = new GameIdleState();

        private IState _currentState;

        public void SetFightState()
        {
            if (_currentState == FightState)
            {
                return;
            }
            
            _currentState?.Exit();
            FightState.Enter();
        }

        public void SetIdleState()
        {
            if (_currentState == IdleState)
            {
                return;
            }
            
            _currentState?.Exit();
            IdleState.Enter();
        }
    }
}