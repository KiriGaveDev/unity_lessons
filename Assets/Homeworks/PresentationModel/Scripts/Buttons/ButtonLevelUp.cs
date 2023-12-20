using Lessons.Architecture.PM;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonLevelUp : MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] private Button button;
    [SerializeField] private Image buttonBackground;

    private PlayerLevel _playerLevel;


    [Inject]
    public void Construct(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
    }


    public void Initialize()
    {
        button.onClick.AddListener(OnClick);
        TryToChangeColor();
        _playerLevel.OnExperienceChanged += PlayerLevel_OnExperienceChanged;
        _playerLevel.OnLevelUp += PlayerLevel_OnLevelUp;
    }
    

    public void Dispose()
    {
        button.onClick.RemoveListener(OnClick);
        _playerLevel.OnExperienceChanged -= PlayerLevel_OnExperienceChanged;
        _playerLevel.OnLevelUp -= PlayerLevel_OnLevelUp;
    }


    private void TryToChangeColor()
    {
        buttonBackground.color = _playerLevel.CanLevelUp() ? Color.green : Color.red;
    }


    private void OnClick()
    {
        _playerLevel.LevelUp();
    }


    private void PlayerLevel_OnExperienceChanged(int obj)
    {
        TryToChangeColor();
    } 
      

    private void PlayerLevel_OnLevelUp()
    {
        TryToChangeColor();
    }
}
