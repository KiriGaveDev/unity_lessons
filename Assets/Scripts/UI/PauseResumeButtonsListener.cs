using ShootEmUp;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeButtonsListener : MonoBehaviour, 
    GameListener.IStartListener,
    GameListener.IFinishListener
{

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;

    public void OnStart()
    {     
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        resumeButton.onClick.AddListener(OnResumeButtonClicked);
    }


    public void OnFinish()
    {
        pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
        resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
    }


    private void OnResumeButtonClicked()
    {
        gameManager.OnResume();
    }


    private void OnPauseButtonClicked()
    {
        gameManager.OnPause();
    }
}
