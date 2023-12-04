using ShootEmUp;
using UnityEngine;
using Zenject;

public class EnemySystemInstaller : MonoInstaller
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private EnemyCooldowmSpawner enemyCooldowmSpawner;

    public override void InstallBindings()
    {
        Container.Bind<EnemyPool>().FromInstance(enemyPool).AsSingle().NonLazy();
        Container.Bind<EnemyManager>().AsSingle().NonLazy();
        Container.Bind<EnemyCooldowmSpawner>().FromInstance(enemyCooldowmSpawner).AsSingle().NonLazy();
    }
}
