using ShootEmUp;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI textComponent; 
    [SerializeField] private GameObject pauseButton;

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
        int remineTime = seconds;

        for (int i = 0; i <= seconds; i++)
        {
            textComponent.text = remineTime.ToString();
            yield return new WaitForSecondsRealtime(1);
            remineTime--;
        }

        gameManager.OnStart();
        gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
