using Scripts.Infrastructure.Services.Input;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }
        public void Exit()
        {

        }

        private void RegisterServices()
        {
            RegisterInputService();
        }
        private void RegisterInputService()
        {
            if (Application.isEditor)
                Game.InputServices = new StandaloneInputService();
            else
                Game.InputServices = new MobileInputService();
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }
    }
}
