public class GameListener
{
    public interface IGameListener
    {

    }

    public interface IStartListener : IGameListener
    {
        public void OnStart();
    }

    public interface IPauseListener : IGameListener
    {
        public void OnPause();
    }

    public interface IResumeListener : IGameListener
    {
        public void OnResume();
    }

    public interface IFinishListener : IGameListener
    {
        public void OnFinish();
    }

    public interface IUpdateListener : IGameListener
    {
        public void OnUpdate(float deltaTime);
    }

    public interface IFixedUpdateListener : IGameListener
    {
        public void OnFixedUpdate(float fixedDeltaTime);
    }

    public interface ILateUpdateListener : IGameListener
    {
        public void OnLateUpdate(float deltaTime);
    }

}
