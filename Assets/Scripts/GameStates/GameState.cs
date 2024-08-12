using States;
using States.GameStateMachine;
using UnityEngine;

namespace GameStates
{
    public class GameState : MonoBehaviour
    {
        public static GameFightState FightState { get; private set; }
        public static GameIdleState IdleState { get; private set; }
        
        private static GameStateMachine _stateMachine;
        
        public void Init()
        {
            _stateMachine = new GameStateMachine();
            FightState = (GameFightState)_stateMachine.States[States.GameStateMachine.GameStates.FightState];
            IdleState = (GameIdleState)_stateMachine.States[States.GameStateMachine.GameStates.IdleState];
        }
        
        public static void SetFightState()
        {
            _stateMachine.ChangeState(States.GameStateMachine.GameStates.FightState);
        }

        public static void SetIdleState()
        {
            _stateMachine.ChangeState(States.GameStateMachine.GameStates.IdleState);
        }

        public static IState GetCurrentState()
        {
            return _stateMachine.CurrentState;
        }
    }
}