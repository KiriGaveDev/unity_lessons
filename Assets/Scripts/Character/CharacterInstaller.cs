using Bullets;
using ShootEmUp;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private MoveComponent characterMoveComponent;
        [SerializeField] private HitPointsComponent characterHitsComponent;

        [SerializeField] private BulletConfig bulletConfig;


        public override void InstallBindings()
        {         
            Container.Bind<CharacterAttackAgent>().AsSingle().WithArguments(weaponComponent, bulletConfig).NonLazy();

            Container.BindInterfacesTo<CharacterDeathObserver>().AsSingle().WithArguments(characterHitsComponent).NonLazy();
            Container.BindInterfacesTo<CharacterMoveController>().AsSingle().WithArguments(characterMoveComponent).NonLazy();
            Container.BindInterfacesTo<CharacterAttackController>().AsSingle().NonLazy();
        }
    }

}
