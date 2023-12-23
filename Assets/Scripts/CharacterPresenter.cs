using Character;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterPresenter : ICharacterPresenter, IDisposable
{
    public event Action<int> OnExperienceChanged;
    public event Action OnLevelUp;

    public string UserName { get; }

    public string Description { get; }

    public int RequiredExperience => _playerLevel.RequiredExperience;

    public Sprite Icon { get; }

    public int Level => _playerLevel.CurrentLevel;

    public int CurrentExperience => _playerLevel.CurrentExperience;

    public HashSet<CharacterStat> CharacterStats => _characterInfo.Stats;


    private readonly CharacterLevel _playerLevel;  
    private readonly Character.CharacterInfo _characterInfo;
    private readonly CharacterLevelData _characterLevelData;


    [Inject]
    public CharacterPresenter(CharacterLevel playerLevel, Character.CharacterInfo characterInfo, CharacterLevelData characterLevelData)
    {
        _playerLevel = playerLevel;      
        _characterInfo = characterInfo;
        _characterLevelData = characterLevelData;

        UserName = _characterLevelData.CharacterLevelSettings.userName;
        Description = _characterLevelData.CharacterLevelSettings.descritrion;
        Icon = _characterLevelData.CharacterLevelSettings.icon;

        AddStats();

        _playerLevel.OnExperienceChanged += PlayerLevel_OnExperienceChanged;
        _playerLevel.OnLevelUp += PlayerLevel_OnlevelUp;
    }


    private void AddStats()
    {
        foreach (StatSettings starts in _characterLevelData.GetCharacterStats())
        {            
            _characterInfo.AddStat(new CharacterStat(starts.nameStat, _characterLevelData.GetValueByLevel(starts.nameStat,Level)));            
        }
    }


    private void UpdateStatsData()
    {
        foreach (CharacterStat stats in CharacterStats)
        {
            stats.ChangeValue(_characterLevelData.GetValueByLevel(stats.Name, Level));
        }
    }


    private void PlayerLevel_OnlevelUp()
    {
        UpdateStatsData();
        OnLevelUp?.Invoke();
    }


    private void PlayerLevel_OnExperienceChanged(int value)
    {
        OnExperienceChanged?.Invoke(value);
    }


    public void Dispose()
    {
        _playerLevel.OnExperienceChanged -= PlayerLevel_OnExperienceChanged;
        _playerLevel.OnLevelUp -= PlayerLevel_OnlevelUp;
    }
}



