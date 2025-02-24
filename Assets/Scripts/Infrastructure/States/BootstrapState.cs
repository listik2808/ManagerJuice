using Scripts.Infrastructure.AssetManagement;
using Scripts.Infrastructure.Services;
using Scripts.Infrastructure.Services.Input;
using Scripts.Infrastructure.States;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string MainScene = "Main";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }
        public void Exit()
        {

        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputServices>(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(MainScene);
        }

        private static IInputServices InputService()
        {
            if (Application.isEditor)// Нужно изменить на комп
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}
