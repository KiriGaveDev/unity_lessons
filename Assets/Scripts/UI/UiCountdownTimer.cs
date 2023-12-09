using System;
using System.Collections;
using TMPro;
using UnityEngine;


namespace UI
{
    public class UiCountdownTimer : MonoBehaviour
    {
        public event Action OnCompleted;

        [SerializeField] private TextMeshProUGUI textComponent;


        private void Awake()
        {
            gameObject.SetActive(false);
        }


        public void StartTimer(int second)
        {
            StartCoroutine(StartTimerRoutine(second));
        }


        private IEnumerator StartTimerRoutine(int seconds)
        {
            int remainingTime = seconds;

            for (int i = 0; i <= seconds; i++)
            {
                textComponent.text = remainingTime.ToString();
                yield return new WaitForSecondsRealtime(1);
                remainingTime--;
            }

            gameObject.SetActive(false);
            OnCompleted?.Invoke();
        }
    }

}
