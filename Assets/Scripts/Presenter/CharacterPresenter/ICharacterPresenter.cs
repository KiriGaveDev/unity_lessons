using Character;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Presenter.CharacterPresenter
{
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

}
