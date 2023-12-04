using ShootEmUp;
using UnityEngine;
using Zenject;

public class BulletSystemInstaller : MonoInstaller
{
    [SerializeField] private BulletPool bulletPool;

    public override void InstallBindings()
    {
        Container.Bind<BulletPool>().FromInstance(bulletPool).AsSingle().NonLazy();
        Container.Bind<BulletSystem>().AsSingle().NonLazy();
    }
}
