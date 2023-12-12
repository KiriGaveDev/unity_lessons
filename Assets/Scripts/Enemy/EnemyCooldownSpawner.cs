using System.Collections;
using UnityEngine;
using Zenject;


namespace Enemies
{
    public class EnemyCooldownSpawner : MonoBehaviour, IPauseListener, IResumeListener, IStartListener
    {
        [SerializeField] private float cooldownSec;

        private EnemyManager _enemyManager;
        private bool _canSpawn = false;


        [Inject]
        public void Construct(EnemyManager enemyManager)
        {        
            this._enemyManager = enemyManager;
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(cooldownSec);

                if (_canSpawn)
                {
                    _enemyManager.SpawnEnemy();
                }
            }
        }


        public void OnPause()
        {
            _canSpawn = false;
        }

        public void OnResume()
        {
            _canSpawn = true;
        }

        public void OnStart()
        {
            _canSpawn = true;
        }
    }
}

