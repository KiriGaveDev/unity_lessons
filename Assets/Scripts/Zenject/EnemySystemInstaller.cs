using ShootEmUp;
using UnityEngine;
using Zenject;

public class EnemySystemInstaller : MonoInstaller
{
    [SerializeField] private EnemyPool enemyPool;

    public override void InstallBindings()
    {
        Container.Bind<EnemyPool>().FromInstance(enemyPool).AsSingle().NonLazy();

    }
}
