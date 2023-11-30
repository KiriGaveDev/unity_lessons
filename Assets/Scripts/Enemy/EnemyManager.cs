using System.Collections.Generic;
using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour, IPauseListener, IResumeListener
    {
        [SerializeField] private EnemyPool enemyPool;     
                     
        private readonly HashSet<Enemy> activeEnemies = new();
               

        public void SpawnEnemy()
        {
            var enemy = this.enemyPool.SpawnEnemy();
            if (enemy != null)
            {
                if (this.activeEnemies.Add(enemy))
                {
                    enemy.HitPointsComponent.OnHpEmpty += this.OnDestroyed;
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
                enemyComponent.HitPointsComponent.OnHpEmpty -= this.OnDestroyed;
                enemyPool.UnspawnEnemy(enemyComponent);
            }
        }


        public void OnPause()
        {
            foreach(var enemy in activeEnemies)
            {
                enemy.Pause();
            }
        }


        public void OnResume()
        {
            foreach (var enemy in activeEnemies)
            {
                enemy.Resume();
            }
        }
    }
}