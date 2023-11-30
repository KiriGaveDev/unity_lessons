using ShootEmUp;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UiCountdownTimer : MonoBehaviour
{
    public Action OnCompleted;
       
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
        int reminingTime = seconds;

        for (int i = 0; i <= seconds; i++)
        {
            textComponent.text = reminingTime.ToString();
            yield return new WaitForSecondsRealtime(1);
            reminingTime--;
        }

        gameObject.SetActive(false);
        OnCompleted?.Invoke();        
    }
}
