using ShootEmUp;
using System.Collections;
using UnityEngine;


public class EnemyCooldowmSpawner : MonoBehaviour
{
    [SerializeField] private float cooldownSec;
    [SerializeField] private EnemyManager enemyManager;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldownSec);
            enemyManager.SpawnEnemy();
        }
    }
}
