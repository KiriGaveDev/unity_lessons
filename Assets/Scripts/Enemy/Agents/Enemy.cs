using ShootEmUp;
using UnityEngine;

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


    public void Pause()
    {     
        enemyAttackAgent.enabled = false;
        enemyMoveAgent.enabled = false;
    }

    public void Resume()
    {      
        enemyAttackAgent.enabled = true;
        enemyMoveAgent.enabled = true;
    }

    public void OnStart()
    {
        enemyAttackAgent.enabled = true;
        enemyMoveAgent.enabled = true;
    }

}
