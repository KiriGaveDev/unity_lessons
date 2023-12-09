using ShootEmUp;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform background;

        [SerializeField] private LevelBackground.Params backgroundParameters;

        [SerializeField] private Transform leftBorder;
        [SerializeField] private Transform rightBorder;
        [SerializeField] private Transform downBorder;
        [SerializeField] private Transform topBorder;


        public override void InstallBindings()
        {
            LevelBounds bounds = new (leftBorder, rightBorder, downBorder, topBorder);
            Container.BindInstance(bounds).AsSingle().NonLazy();

            LevelBackground levelBackground = new(backgroundParameters, background);
            Container.BindInterfacesTo<LevelBackground>().FromInstance(levelBackground).AsTransient().NonLazy();
        }
    }
}

