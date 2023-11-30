using UnityEngine;
using UnityEngine.UI;

public class StartButtonListener : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private UiCountdownTimer timer;
    [SerializeField] private int time;


    private void Awake()
    {
        startButton.onClick.AddListener(StartButton_OnClick);
    }


    private void StartButton_OnClick()
    {
        StartGame();
    }

   
    public void StartGame()
    {
        timer.gameObject.SetActive(true);
        timer.StartTimer(time);

        startButton.gameObject.SetActive(false);
    }
}
