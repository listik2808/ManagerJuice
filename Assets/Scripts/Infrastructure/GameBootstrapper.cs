using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour//,ICoroutineRunner
    {
        //private Game _game;

        private void Awake()
        {
            //_game = new Game(this);
            //_game.StateMashine.Enter<BootstarpState>();
            DontDestroyOnLoad(this);
        }
    }
}
