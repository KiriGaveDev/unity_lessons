using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    public class PauseResumeButtonStateController : MonoBehaviour,
       IStartListener,
       IPauseListener,
       IResumeListener,
       IFinishListener
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
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
        }

        public void OnResume()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }
    }
}

