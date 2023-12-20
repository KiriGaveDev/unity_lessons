using CharacterUI;
using Zenject;


namespace Character
{
    public class CharacterInstaller : MonoInstaller<CharacterInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterPopup>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<CharacterLevel>().AsSingle().NonLazy();
            Container.Bind<UserInfo>().AsSingle().NonLazy();
            Container.Bind<CharacterInfo>().AsSingle().NonLazy();            
        }
    }
}

