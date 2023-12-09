using Character;
using ShootEmUp;
using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private MoveComponent characterMoveComponent;
    [SerializeField] private HitPointsComponent characterHitsComponent;

    [SerializeField] private BulletConfig bulletConfig;
    [SerializeField] private GameManager gameManager;




    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle().NonLazy();

       // Container.Bind<GameManagerInstaller>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<BulletConfig>().FromInstance(bulletConfig).AsSingle().NonLazy();

        Container.Bind<WeaponComponent>().FromInstance(weaponComponent).AsSingle().NonLazy();
        Container.Bind<HitPointsComponent>().FromInstance(characterHitsComponent).AsSingle().NonLazy();
        Container.Bind<MoveComponent>().FromInstance(characterMoveComponent).AsSingle().NonLazy();
        Container.Bind<CharacterAttackAgent>().AsSingle().NonLazy();

        Container.BindInterfacesTo<CharacterDeathObserver>().AsSingle().NonLazy();
        Container.BindInterfacesTo<CharacterMoveController>().AsSingle().NonLazy();
        Container.BindInterfacesTo<CharacterAttackController>().AsSingle().NonLazy();

    }
}
