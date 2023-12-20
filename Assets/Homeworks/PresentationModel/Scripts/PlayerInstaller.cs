using Lessons.Architecture.PM;
using Zenject;


public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<CharacterPopup>().FromComponentInHierarchy().AsSingle().NonLazy();
        //
        Container.BindInterfacesTo<ButtonAddExperience>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesTo<ButtonLevelUp>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesTo<ButtonChangeName>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesTo<ButtonChangeDescription>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesTo<ButtonChangeIcon>().FromComponentInHierarchy().AsSingle().NonLazy();
        //
        Container.Bind<PlayerLevel>().AsSingle().NonLazy();
        Container.Bind<UserInfo>().AsSingle().NonLazy();
    }
}
