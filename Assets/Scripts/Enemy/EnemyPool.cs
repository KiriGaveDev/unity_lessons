using Bullets;
using Enemies.Agents;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private int enemyCount = 6;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private Transform character;

        private BulletSystem _bulletSystem;

        [SerializeField] private Transform worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform container;

        [Header("Prefabs")]
        [SerializeField] private Enemy prefab;

        private readonly Queue<Enemy> enemyPool = new();

        [Inject]
        private void Construct(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }

        private void Awake()
        {
            for (var i = 0; i <= enemyCount; i++)
            {
                var enemy = Instantiate(prefab, container);
                enemy.InitEnemyAttack(_bulletSystem, character);             
                enemyPool.Enqueue(enemy);
            }
        }


        public bool TrySpawnEnemy(out Enemy enemy) => enemyPool.TryDequeue(out enemy);



        public Enemy SpawnEnemy()
        {
            if (!TrySpawnEnemy(out Enemy enemy))
            {
                return null;
            }

            enemy.transform.SetParent(this.worldTransform);

            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = this.enemyPositions.RandomAttackPosition();
            enemy.EnemyMoveAgent.SetDestination(attackPosition.position);

            
            return enemy;
        }


        public void UnspawnEnemy(Enemy enemy)
        {
            enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}