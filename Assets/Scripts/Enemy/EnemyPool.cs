using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private Transform character;

        [SerializeField] private BulletSystem _bulletSystem;

        [SerializeField]
        private Transform worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private Enemy prefab;

        private readonly Queue<Enemy> enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < 7; i++)
            {
                var enemy = Instantiate(this.prefab, this.container);
                enemy.InitEnemyAttack(this._bulletSystem, this.character);             
                this.enemyPool.Enqueue(enemy);
            }
        }

        public Enemy SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
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