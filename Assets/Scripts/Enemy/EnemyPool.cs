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
        private readonly Transform _worldTransform;
        private readonly Transform _container;
        private readonly EnemyFactory _enemyFactory;


        private readonly Queue<Enemy> enemyPool = new();

        [Inject]
        public EnemyPool(EnemyFactory enemyFactory, Transform worldTransform, int enemyCount, EnemyPositions enemyPositions, Transform container)
        {            
            _enemyFactory = enemyFactory;
            _worldTransform = worldTransform;
            _enemyCount = enemyCount;
            _enemyPositions = enemyPositions;        
            _container = container;
        }


        public void Initialize()
        {
            for (var i = 0; i <= _enemyCount; i++)
            {
                var enemy = _enemyFactory.CreateEnemy();
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