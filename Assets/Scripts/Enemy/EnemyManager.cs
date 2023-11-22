using System.Collections.Generic;
using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private EnemyPool enemyPool;     
                     
        private readonly HashSet<Enemy> m_activeEnemies = new();
               

        public void SpawnEnemy()
        {
            var enemy = this.enemyPool.SpawnEnemy();
            if (enemy != null)
            {
                if (this.m_activeEnemies.Add(enemy))
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

            if (m_activeEnemies.Remove(enemyComponent))
            {
                enemyComponent.HitPointsComponent.OnHpEmpty -= this.OnDestroyed;
                enemyPool.UnspawnEnemy(enemyComponent);
            }
        }


        public void OnPauseGame()
        {
            foreach(var enemy in m_activeEnemies)
            {
                enemy.Pause();
            }
        }


        public void OnResumeGame()
        {
            foreach (var enemy in m_activeEnemies)
            {
                enemy.Resume();
            }
        }
    }
}