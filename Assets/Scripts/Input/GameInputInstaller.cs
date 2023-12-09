using Game_Input;
using Zenject;

public class GameInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        IInputService inputService = new KeyboardInput();
        Container.BindInterfacesAndSelfTo<IInputService>().FromInstance(inputService).AsSingle().NonLazy();
    }
}
