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
public class CharacterLevelData : ScriptableObject
{
    [SerializeField] private CharacterLevelSettings characterLevelSettings;

    public CharacterLevelSettings CharacterLevelSettings => characterLevelSettings;


    public ExperienceSettings GetRequireExp(int level) => characterLevelSettings.experienceSettings[level];


    public List<StatSettings> GetCharacterStats()
    {
        return characterLevelSettings.statSettings;
    }

    public int GetValueByLevel(string name, int level)
    {
        for (int i = 0; i < characterLevelSettings.statSettings.Count; i++)
        {
            if (characterLevelSettings.statSettings[i].nameStat == name)
            {
                return characterLevelSettings.statSettings[i].value[level];
            }
        }

        return 0;
    }
}
