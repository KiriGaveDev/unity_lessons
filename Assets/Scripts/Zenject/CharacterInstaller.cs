using ShootEmUp;
using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private BulletSystem bulletSystem;
    [SerializeField] private BulletConfig bulletConfig;

    [SerializeField] private HitPointsComponent characterHitsComponent;
    [SerializeField] private GameManager gameManager;


    public override void InstallBindings()
    {
        Container.Bind<BulletSystem>().FromInstance(bulletSystem).AsSingle().NonLazy();
        Container.Bind<BulletConfig>().FromInstance(bulletConfig).AsSingle().NonLazy();
        Container.Bind<WeaponComponent>().FromInstance(weaponComponent).AsSingle().NonLazy();
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle().NonLazy();
        Container.Bind<CharacterAttackComponent>().AsSingle().NonLazy();
        //Container.Bind<CharacterDeathObserver>().AsSingle().NonLazy();

        Container.BindInterfacesTo<CharacterAttackController>().AsSingle().NonLazy();

    }
}
