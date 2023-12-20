using Zenject;

namespace ButtonsHelpers
{
    public class ButtonHealpersInstaller : MonoInstaller<ButtonHealpersInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ButtonAddExperience>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ButtonLevelUp>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ButtonChangeName>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ButtonChangeDescription>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesTo<ButtonChangeIcon>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}