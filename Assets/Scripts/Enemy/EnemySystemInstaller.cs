using Enemies.Agents;
using UnityEngine;
using Zenject;


namespace Enemies
{
    public class EnemySystemInstaller : MonoInstaller
    {
        [SerializeField] private int enemyCount = 6;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private Transform character;
       
        [SerializeField] private Transform container;
        [SerializeField] private Enemy prefab;

        [SerializeField] private EnemyCooldownSpawner enemyCooldowmSpawner;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyPool>().AsSingle().WithArguments(enemyCount, enemyPositions, character, container, prefab).NonLazy();
            Container.Bind<EnemyManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyCooldownSpawner>().FromInstance(enemyCooldowmSpawner).AsSingle().NonLazy();
        }
    }
}

