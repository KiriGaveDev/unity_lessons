using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            None,
            Started,
            Paused,
            Resumed,
            Finished            
        }

        private GameState currentGameState;
        public List<GameListener.IGameListener> gameListeners = new List<GameListener.IGameListener>();
             

        public void AddListener(GameListener.IGameListener listener)
        {
            gameListeners.Add(listener);
        }


        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        public bool IsGamePaused()
        {
           return currentGameState == GameState.Paused;
        }


        public void OnStart()
        {
            foreach (var gameListener in gameListeners)
            {
                if(gameListener is GameListener.IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }
            currentGameState = GameState.Started;
        }

        
        public void Pause()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IGamePauseListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }

            currentGameState = GameState.Paused;
        }


        public void Resume()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }

            currentGameState = GameState.Resumed;
        }
    }
}