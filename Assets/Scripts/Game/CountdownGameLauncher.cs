using UI;
using UnityEngine;


namespace Game
{
    public class CountdownGameLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private UiCountdownTimer uiTimer;

        private void Awake()
        {
            uiTimer.OnCompleted += UiTimer_OnCompleted;
        }


        private void UiTimer_OnCompleted()
        {
            gameManager.OnStart();
            uiTimer.OnCompleted -= UiTimer_OnCompleted;
        }
    }
}

