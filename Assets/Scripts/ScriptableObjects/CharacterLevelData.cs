using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatSettings
{
    public string nameStat;
    public List<int> value;
}

[Serializable]
public class ExperienceSettings
{
    public int requireExp;
}


[Serializable]
public class CharacterLevelSettings
{
    public string userName;
    public string descritrion;
    public Sprite icon;

    public List<ExperienceSettings> experienceSettings;
    public List<StatSettings> statSettings;
}


[CreateAssetMenu(fileName = "CharacterLevelData", menuName = "Configs/CharacterLevelData")]
public sealed class CharacterLevelData : ScriptableObject
{
    [SerializeField] private CharacterLevelSettings _characterLevelSettings;

    public CharacterLevelSettings CharacterLevelSettings => _characterLevelSettings;


    public ExperienceSettings GetRequireExp(int level) => _characterLevelSettings.experienceSettings[level];


    public List<StatSettings> GetCharacterStats()
    {
        return _characterLevelSettings.statSettings;
    }


    public int GetValueByLevel(string name, int level)
    {
        for (int i = 0; i < _characterLevelSettings.statSettings.Count; i++)
        {
            if (_characterLevelSettings.statSettings[i].nameStat == name)
            {
                return _characterLevelSettings.statSettings[i].value[level];
            }
        }

        return 0;
    }
}
