using ShootEmUp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseResumeButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI textComponent;

    private void Awake()
    {
        button.onClick.AddListener(Button_OnClick);
    }


    private void Button_OnClick()
    {        
        if (gameManager.IsGamePaused())
        {
            gameManager.Resume();
            textComponent.text = "Pause";
        }
        else
        {
            gameManager.Pause();
            textComponent.text = "Resume";
        }
    }
}
