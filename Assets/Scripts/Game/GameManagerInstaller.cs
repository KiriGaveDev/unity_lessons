using ShootEmUp;
using UnityEngine;

public class GameManagerInstaller : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] rootListenerObjects;


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
     
    }
}
