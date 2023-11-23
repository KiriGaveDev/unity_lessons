using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        button.onClick.AddListener(Button_OnClick);
    }


    private void Button_OnClick()
    {
        timer.gameObject.SetActive(true);
        timer.TryStartTimer();
        gameObject.SetActive(false);
    }
}
