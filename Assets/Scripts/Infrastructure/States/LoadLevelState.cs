using Scripts.Hero;
using UnityEngine;

namespace Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string InitialPoint = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader,IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPoint);

            GameObject hero = _gameFactory.CreateHero(initialPoint);
            HeroMove heroMove = hero.GetComponent<HeroMove>();
            HeroAnimation heroAnimator = hero.GetComponent<HeroAnimation>();
            heroAnimator.Constroct(heroMove);
            //_gameFactory.CreateHud();

            CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        

        private void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}
