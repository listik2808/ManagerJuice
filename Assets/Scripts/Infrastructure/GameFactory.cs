using Scripts.Infrastructure.AssetManagement;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assets)
        {
            _assetProvider = assets;
        }

        public GameObject CreateHero(GameObject point)
        {
            return _assetProvider.Instantiate(AssetPath.HeroPath, point.transform.position);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.Hud);
        }
    }
}
