using Character;
using System;
using UnityEngine;
using Zenject;

public class CharacterPresenter : ICharacterPresenter
{
    public event Action<int> OnExperienceChanged;

    public string UserName { get; }

    public string Description { get; }

    public int CurrentExperience { get; }

    public int RequiredExperience { get; }

    public int Level { get; }

    public Sprite Icon { get; }



    private CharacterLevel _playerLevel;
    private UserInfo _userInfo;
    private Character.CharacterInfo _characterInfo;
    private CharacterLevelData _characterLevelData;


    [Inject]
    public CharacterPresenter(CharacterLevel playerLevel, UserInfo userInfo, Character.CharacterInfo characterInfo, CharacterLevelData characterLevelData)
    {
        _playerLevel = playerLevel;
        _userInfo = userInfo;
        _characterInfo = characterInfo;
        _characterLevelData = characterLevelData;

        UserName = _characterLevelData.CharacterLevelSettings.userName;
        Description = _characterLevelData.CharacterLevelSettings.descritrion;
        CurrentExperience = _playerLevel.CurrentExperience;
        RequiredExperience = _characterLevelData.GetRequireExp(_playerLevel.CurrentLevel).requireExp;
        Level = _playerLevel.CurrentLevel;
        Icon = _characterLevelData.CharacterLevelSettings.icon;

        _playerLevel.OnExperienceChanged += PlayerLevel_OnExperienceChanged;
    }


    private void PlayerLevel_OnExperienceChanged(int value)
    {
        OnExperienceChanged?.Invoke(value);
    }   
}


   
