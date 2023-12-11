using ShootEmUp;
using UnityEngine;
using Zenject;


namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameManager gameManager;

        public override void InstallBindings()
        {
            Container.BindInstance(gameManager);
        }
    }
}



