using ShootEmUp;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private int time;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void TryStartTimer()
    {
        StartCoroutine(StartTimer());
    }


    public IEnumerator StartTimer()
    {
        int remineTime = time;

        for (int i = 0; i <= time; i++)
        {
            textComponent.text = remineTime.ToString();
            yield return new WaitForSecondsRealtime(1);
            remineTime--;
        }

        gameManager.OnStart();
        gameObject.SetActive(false);
    }

    

}
