using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] rootListenerObjects;

    private List<GameListener.IGameListener> _diGameListeners = new();


    [Inject]
    public void Construct(List<GameListener.IGameListener> gameListeners)
    {        
        _diGameListeners = gameListeners;
    }


    private void Awake()
    {
        foreach (GameObject rootObject in rootListenerObjects)
        {
            var listeners = rootObject.GetComponentsInChildren<GameListener.IGameListener>();

            foreach (var listener in listeners)
            {
                gameManager.AddListener(listener);
            }
        }


        for(int i = 0; i < _diGameListeners.Count; i++)
        {
            gameManager.AddListener(_diGameListeners[i]);
        }

    }
}
