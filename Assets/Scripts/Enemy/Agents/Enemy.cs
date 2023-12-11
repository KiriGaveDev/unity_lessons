using Bullets;
using ShootEmUp;
using UnityEngine;

namespace Enemies.Agents
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent enemyMoveAgent;

        public HitPointsComponent HitPointsComponent => hitPointsComponent;
        public EnemyAttackAgent EnemyAttackAgent => enemyAttackAgent;
        public EnemyMoveAgent EnemyMoveAgent => enemyMoveAgent;


        public void InitEnemyAttack(BulletSystem bulletSystem, Transform character)
        {
            EnemyAttackAgent.Init(bulletSystem, character);
        }

    }

}
