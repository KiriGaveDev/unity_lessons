using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        private enum GameState
        {
            None,
            Started,
            Paused,
            Playing,
            Finished            
        }

        private GameState currentGameState;
        public List<GameListener.IGameListener> gameListeners = new ();

        public List<GameListener.IUpdateListener> updateListeners = new ();
        public List<GameListener.IFixedUpdateListener> fixedUpdateListeners = new ();
        public List<GameListener.ILateUpdateListener> lateUpdateListeners = new ();


        public void AddListener(GameListener.IGameListener listener)
        {
            gameListeners.Add(listener);

            if (listener is GameListener.IUpdateListener updateListener)
            {
                updateListeners.Add(updateListener);
            }

            if (listener is GameListener.IFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (listener is GameListener.ILateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Add(lateUpdateListener);
            }
        }


        public void RemoveListener(GameListener.IGameListener listener)
        {
            gameListeners.Remove(listener);

            if (listener is GameListener.IUpdateListener updateListener)
            {
                updateListeners.Remove(updateListener);
            }

            if (listener is GameListener.IFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Remove(fixedUpdateListener);
            }

            if (listener is GameListener.ILateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Remove(lateUpdateListener);
            }
        }


        public void FinishGame()
        {
            if(currentGameState == GameState.None || currentGameState == GameState.Finished)
            {
                return;
            }

            OnFinished();

            Debug.Log("Game over!");
            Time.timeScale = 0;
        }


        public void OnStart()
        {
            if(currentGameState != GameState.None)
            {
                return;
            }

            foreach (var gameListener in gameListeners)
            {
                if(gameListener is GameListener.IStartListener startListener)
                {
                    startListener.OnStart();
                }
            }
            currentGameState = GameState.Started;
        }

        
        public void OnPause()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IPauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            currentGameState = GameState.Paused;
        }


        public void OnResume()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            currentGameState = GameState.Playing;
        }


        public void OnFinished()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IFinishListener resumeListener)
                {
                    resumeListener.OnFinish();
                }
            }

            currentGameState= GameState.Finished;
        }


        public void OnUpdate()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IUpdateListener updateListener)
                {
                    updateListener.OnUpdate(Time.deltaTime);
                }
            }            
        }


        public void OnFixedUpdate()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.IFixedUpdateListener fixedUpdateListener)
                {
                    fixedUpdateListener.OnFixedUpdate(Time.fixedDeltaTime);
                }
            }                        
        }


        public void OnLateUpdate()
        {
            foreach (var gameListener in gameListeners)
            {
                if (gameListener is GameListener.ILateUpdateListener lateUpdateListener)
                {
                    lateUpdateListener.OnLateUpdate(Time.deltaTime);
                }
            }           
        }
    }
}