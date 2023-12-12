using Bullets;
using Enemies.Agents;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public sealed class EnemyPool : IInitializable
    {     
        private readonly int _enemyCount = 6;

        private readonly EnemyPositions _enemyPositions;
        private readonly Transform _character;
        private readonly BulletSystem _bulletSystem;
        private readonly Transform _worldTransform;
        private readonly Transform _container;

        private readonly Enemy _prefab;

        private readonly Queue<Enemy> enemyPool = new();

        [Inject]
        public EnemyPool(BulletSystem bulletSystem, Transform worldTransform, int enemyCount, EnemyPositions enemyPositions, Transform character, Transform container, Enemy prefab)
        {
            _bulletSystem = bulletSystem;
            _worldTransform = worldTransform;
            _enemyCount = enemyCount;
            _enemyPositions = enemyPositions;
            _character = character;
            _container = container;
            _prefab = prefab;
        }


        public void Initialize()
        {
            for (var i = 0; i <= _enemyCount; i++)
            {
                var enemy = Object.Instantiate(_prefab, _container);
                enemy.InitEnemyAttack(_bulletSystem, _character);
                enemyPool.Enqueue(enemy);
            }
        }

   
        public Enemy SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.EnemyMoveAgent.SetDestination(attackPosition.position);

            return enemy;
        }
             


        public void UnspawnEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(this._container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}