using Bullets;
using Enemies.Agents;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab;
        private readonly Transform _container;
        private readonly BulletSystem _bulletSystem;
        private readonly Transform _character;


        [Inject]
        public EnemyFactory(BulletSystem bulletSystem,Enemy prefab, Transform container, Transform character)
        {
            _bulletSystem = bulletSystem;
            _prefab = prefab;
            _container = container;
            _character = character;
        }


        public Enemy CreateEnemy()
        {
            var enemy = Object.Instantiate(_prefab, _container);
            enemy.InitEnemyAttack(_bulletSystem, _character);
            return enemy;
        }
    }
}

