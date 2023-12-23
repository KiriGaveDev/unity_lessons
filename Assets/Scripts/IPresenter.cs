using Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPresenter 
{
  
}

public interface ICharacterPresenter : IPresenter
{
    public string UserName { get; }
    public string Description { get; }
    public int CurrentExperience { get; }
    public int RequiredExperience { get; }
    public int Level { get; }
    public Sprite Icon { get; }
    public HashSet<CharacterStat> CharacterStats { get; }

    event Action<int> OnExperienceChanged;
    event Action OnLevelUp;
}
