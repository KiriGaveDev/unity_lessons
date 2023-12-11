using UnityEngine;
using Zenject;


namespace Enemies
{
    public class EnemySystemInstaller : MonoInstaller
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private EnemyCooldownSpawner enemyCooldowmSpawner;

        public override void InstallBindings()
        {
            Container.Bind<EnemyPool>().FromInstance(enemyPool).AsSingle().NonLazy();
            Container.Bind<EnemyManager>().AsSingle().NonLazy();
            Container.Bind<EnemyCooldownSpawner>().FromInstance(enemyCooldowmSpawner).AsSingle().NonLazy();
        }
    }
}

