using Lessons.Architecture.PM;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonAddExperience : MonoBehaviour, IInitializable
{
    [SerializeField] private int addedValue;
    [SerializeField] private Button button;

    private PlayerLevel playerLevel;


    [Inject]
    public void Construct(PlayerLevel playerLevel)
    {
        this.playerLevel = playerLevel;
    }


    public void Initialize()
    {
        button.onClick.AddListener(OnClick);
    }


    private void OnClick()
    {
        playerLevel.AddExperience(addedValue);
    }
}
