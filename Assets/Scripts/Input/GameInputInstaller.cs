using Zenject;


namespace Game_Input
{
    public class GameInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            IInputService inputService = new KeyboardInput();
            Container.BindInterfacesAndSelfTo<IInputService>().FromInstance(inputService).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<IUpdateListener>().FromInstance(inputService).AsSingle().NonLazy();
        }
    }
}

