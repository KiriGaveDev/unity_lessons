using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
                     
        private readonly HashSet<Enemy> m_activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemy = this.enemyPool.SpawnEnemy();
            if (enemy != null)
            {
                if (this.m_activeEnemies.Add(enemy))
                {
                    enemy.HitPointsComponent.hpEmpty += this.OnDestroyed;
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

            if (m_activeEnemies.Remove(enemyComponent))
            {
                enemyComponent.HitPointsComponent.hpEmpty -= this.OnDestroyed;
                enemyPool.UnspawnEnemy(enemyComponent);
            }
        }     
    }
}