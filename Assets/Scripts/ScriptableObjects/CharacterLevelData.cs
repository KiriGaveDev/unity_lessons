using System;
using System.Collections.Generic;
using UnityEngine;



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
}


[CreateAssetMenu(fileName = "CharacterLevelData", menuName = "Configs/CharacterLevelData")]
public class CharacterLevelData : ScriptableObject
{
    [SerializeField] private CharacterLevelSettings characterLevelSettings;

    public CharacterLevelSettings CharacterLevelSettings => characterLevelSettings;


    public ExperienceSettings GetRequireExp(int level) => characterLevelSettings.experienceSettings[level];
}
