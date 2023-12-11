using UnityEngine;
using Zenject;


namespace Bullets
{
    public class BulletSystemInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;
        [Header("Setting")]
        [SerializeField] private int initialCount;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BulletPool>().AsSingle().WithArguments(prefab, container, worldTransform, initialCount);
            Container.Bind<BulletSystem>().AsSingle().NonLazy();
        }
    }
}


