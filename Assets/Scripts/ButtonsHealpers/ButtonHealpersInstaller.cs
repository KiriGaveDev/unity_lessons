using Zenject;

namespace ButtonsHelpers
{
    public class ButtonHealpersInstaller : MonoInstaller<ButtonHealpersInstaller>
    {
        public override void InstallBindings()
        {         
            Container.BindInterfacesTo<CharacterPopupHelper>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}