using Zenject;

namespace CharacterPopupHelper
{
    public class CharacterPopupHelperInstaller : MonoInstaller<CharacterPopupHelperInstaller>
    {
        public override void InstallBindings()
        {         
            Container.BindInterfacesTo<CharacterPopupHelper>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}