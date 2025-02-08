using Scripts.Infrastructure.Services.Input;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public static IInputServices InputServices;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}
