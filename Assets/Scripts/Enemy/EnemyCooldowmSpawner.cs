using ShootEmUp;
using System.Collections;
using UnityEngine;
using static GameListener;

public class EnemyCooldowmSpawner : MonoBehaviour, IGamePauseListener, IGameResumeListener
{
    [SerializeField] private float cooldownSec;
    [SerializeField] private EnemyManager enemyManager;

    private bool canSpawn = true;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldownSec);

            if (canSpawn)
            {
                enemyManager.SpawnEnemy();
            }            
        }
    }


    public void OnPauseGame()
    {
        canSpawn = false;
    }

    public void OnResumeGame()
    {
        canSpawn = false;
    }
}
