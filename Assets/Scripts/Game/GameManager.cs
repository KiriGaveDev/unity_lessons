using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        private enum GameState
        {
            None,         
            Paused,
            Playing,
            Finished            
        }

        private GameState currentGameState;

        private List<GameListener.IGameListener> gameListeners = new ();
        
        private List<GameListener.IUpdateListener> updateListeners = new ();
        private List<GameListener.IFixedUpdateListener> fixedUpdateListeners = new ();
        private List<GameListener.ILateUpdateListener> lateUpdateListeners = new ();


        private void Update()
        {
            if(currentGameState != GameState.Playing)
            {
                return;
            }

            for (int i = 0; i < updateListeners.Count; i++)
            {
                updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }


        private void FixedUpdate()
        {
            if (currentGameState != GameState.Playing)
            {
                return;
            }

            for (int i = 0; i < fixedUpdateListeners.Count; i++)
            {
                fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }


        private void LateUpdate()
        {
            if (currentGameState != GameState.Playing)
            {
                return;
            }

            for (int i = 0; i < lateUpdateListeners.Count; i++)
            {
                lateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }


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
            currentGameState = GameState.Playing;
        }

        
        public void OnPause()
        {
            if (currentGameState != GameState.Playing)
            {
                return;
            }

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
            if (currentGameState != GameState.Paused)
            {
                return;
            }

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
    }
}