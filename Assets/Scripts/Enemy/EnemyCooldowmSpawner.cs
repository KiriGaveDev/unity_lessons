using ShootEmUp;
using System.Collections;
using UnityEngine;
using Zenject;
using static GameListener;

public class EnemyCooldowmSpawner : MonoBehaviour, IPauseListener, IResumeListener, IStartListener
{
    [SerializeField] private float cooldownSec;

    private EnemyManager enemyManager;
    private bool canSpawn = false;


    [Inject]
    private void Construct(EnemyManager enemyManager)
    {
        this.enemyManager = enemyManager;
    }

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


    public void OnPause()
    {
        canSpawn = false;
    }

    public void OnResume()
    {
        canSpawn = true;
    }

    public void OnStart()
    {
        canSpawn = true;
    }
}
