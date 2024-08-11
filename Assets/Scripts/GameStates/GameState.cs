namespace GameStates
{
    public static class GameState
    {
        public static GameFightState FightState { get; private set; }
        public static GameIdleState IdleState { get; private set; }
        
        public static void Init()
        {
            FightState = new GameFightState();
            IdleState = new GameIdleState();
        }

        public static void ChangeState()
        {
            
        }
    }
}