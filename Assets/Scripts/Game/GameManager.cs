using System.Collections.Generic;
using UnityEngine;

namespace Game
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

        private readonly List<IGameListener> gameListeners = new ();
        
        private readonly List<IUpdateListener> updateListeners = new ();
        private readonly List<IFixedUpdateListener> fixedUpdateListeners = new ();
        private readonly List<ILateUpdateListener> lateUpdateListeners = new ();


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


        public void AddListener(IGameListener listener)
        {
            gameListeners.Add(listener);

            if (listener is IUpdateListener updateListener)
            {
                updateListeners.Add(updateListener);
            }

            if (listener is IFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (listener is ILateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Add(lateUpdateListener);
            }
        }


        public void RemoveListener(IGameListener listener)
        {
            gameListeners.Remove(listener);

            if (listener is IUpdateListener updateListener)
            {
                updateListeners.Remove(updateListener);
            }

            if (listener is IFixedUpdateListener fixedUpdateListener)
            {
                fixedUpdateListeners.Remove(fixedUpdateListener);
            }

            if (listener is ILateUpdateListener lateUpdateListener)
            {
                lateUpdateListeners.Remove(lateUpdateListener);
            }
        }

       
        public void OnStart()
        {
            if(currentGameState != GameState.None)
            {
                return;
            }

            foreach (var gameListener in gameListeners)
            {
                if(gameListener is IStartListener startListener)
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
                if (gameListener is IPauseListener pauseListener)
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
                if (gameListener is IResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            currentGameState = GameState.Playing;
        }


        public void OnFinished()
        {
            if (currentGameState is GameState.None or GameState.Finished)
            {
                return;
            }

            foreach (var gameListener in gameListeners)
            {   
                if (gameListener is IFinishListener resumeListener)
                {   
                    resumeListener.OnFinish();
                }
            }
          
            Debug.Log("Game over!");
            Time.timeScale = 0;

            currentGameState = GameState.Finished;
        }
    }
}