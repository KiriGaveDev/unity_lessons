using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameListener 
{
    public interface IGameListener
    {

    }

    public interface IGameStartListener: IGameListener
    {
        public void OnStartGame();
    }

    public interface IGamePauseListener : IGameListener
    {
        public void OnPauseGame();
    }

    public interface IGameResumeListener : IGameListener
    {
        public void OnResumeGame();
    }

    public interface IGameFinishListener : IGameListener
    {
        public void OnFinishGame();
    }
}
