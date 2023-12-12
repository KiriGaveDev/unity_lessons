using Enemies.Agents;
using Game;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Enemies
{
    public sealed class EnemyManager
    {
        private readonly EnemyPool _enemyPool;
        private readonly GameManager _gameManager;
                     
        private readonly HashSet<Enemy> activeEnemies = new();


        [Inject]
        public EnemyManager(EnemyPool enemyPool, GameManager gameManager)
        {
            this._enemyPool = enemyPool;
            this._gameManager = gameManager;
        }


        public void SpawnEnemy()
        {
            var enemy = _enemyPool.SpawnEnemy();

            if (enemy != null)
            {
                if (activeEnemies.Add(enemy))
                {
                    _gameManager.AddListener(enemy.EnemyAttackAgent);
                    _gameManager.AddListener(enemy.EnemyMoveAgent);

                    enemy.HitPointsComponent.OnHpEmpty += OnDestroyed;
                }
            }
        }


        private void OnDestroyed(GameObject enemy)
        {           
            if(enemy.TryGetComponent(out Enemy enemyComponent))
            {
                return;
            }

            if (activeEnemies.Remove(enemyComponent))
            {
                _gameManager.RemoveListener(enemyComponent.EnemyAttackAgent);
                _gameManager.RemoveListener(enemyComponent.EnemyMoveAgent);
               
                _enemyPool.UnspawnEnemy(enemyComponent);

                enemyComponent.HitPointsComponent.OnHpEmpty -= OnDestroyed;
            }
        }       
    }
}