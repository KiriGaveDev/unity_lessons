using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyManager
    {
        private EnemyPool enemyPool;
        private GameManager gameManager;
                     
        private readonly HashSet<Enemy> activeEnemies = new();


        [Inject]
        public EnemyManager(EnemyPool enemyPool, GameManager gameManager)
        {
            this.enemyPool = enemyPool;
            this.gameManager = gameManager;
        }


        public void SpawnEnemy()
        {
            var enemy = enemyPool.SpawnEnemy();
          
            if (enemy != null)
            {
                if (activeEnemies.Add(enemy))
                {
                    gameManager.AddListener(enemy.EnemyAttackAgent);
                    gameManager.AddListener(enemy.EnemyMoveAgent);

                    enemy.HitPointsComponent.OnHpEmpty += OnDestroyed;
                }
            }
        }


        private void OnDestroyed(GameObject enemy)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();

            if(enemyComponent == null)
            {
                return;
            }

            if (activeEnemies.Remove(enemyComponent))
            {
                gameManager.RemoveListener(enemyComponent.EnemyAttackAgent);
                gameManager.RemoveListener(enemyComponent.EnemyMoveAgent);
               
                enemyPool.UnspawnEnemy(enemyComponent);

                enemyComponent.HitPointsComponent.OnHpEmpty -= OnDestroyed;
            }
        }       
    }
}