using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInstaller : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        var listeners = GetComponentsInChildren<GameListener.IGameListener>();

        foreach (var listener in listeners)
        {
            gameManager.AddListener(listener);
        }
    }
}
