using System.Collections.Generic;
using GameStates;

namespace States.GameStateMachine
{
    public class GameStateMachine : StateMachineBasic<GameStates>
    {
        public GameStateMachine() : base()
        {
            States = new Dictionary<GameStates, IState>()
            {
                { GameStates.FightState, new GameFightState() },
                { GameStates.IdleState, new GameIdleState() }
            };
        }
    }
}