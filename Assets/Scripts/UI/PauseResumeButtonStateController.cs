using UnityEngine;
using UnityEngine.UI;

public class PauseResumeButtonStateController : MonoBehaviour,
    GameListener.IStartListener, 
    GameListener.IPauseListener,
    GameListener.IResumeListener,
    GameListener.IFinishListener
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button pauseButton;

    public void OnStart()
    {
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    public void OnFinish()
    {
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    public void OnPause()
    {
        Debug.LogError("пауза");
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    public void OnResume()
    {
        Debug.LogError("ресуме");
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

 
}
