using Scripts.Hero;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string Path = "Player/Hero";
        private const string Hud = "Infrastructure/Hud";
        private const string InitialPoint = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
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

            GameObject hero = Instantiate(Path, initialPoint.transform.position);
            HeroMove heroMove = hero.GetComponent<HeroMove>();
            HeroAnimation heroAnimator = hero.GetComponent<HeroAnimation>();
            heroAnimator.Constroct(heroMove);
            //Instantiate(Hud);

            CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            GameObject heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }
        private static GameObject Instantiate(string path, Vector3 point)
        {
            GameObject heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab, point, Quaternion.identity);
        }

        private void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}
