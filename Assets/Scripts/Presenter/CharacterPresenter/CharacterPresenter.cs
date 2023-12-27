using Character;
using System.Collections.Generic;
using UnityEngine;


namespace Presenter.CharacterPresenter
{
    public sealed class CharacterPresenter : ICharacterPresenter
    {       
        public HashSet<CharacterStat> CharacterStats => _characterInfo.Stats;

        public ICharacterExperiencePresenter ExperiencePresenter { get; }

        public ICharacterInfoPresenter InfoPresenter { get; }

        public ICharacterStatsPresenter StatsPresenter { get; }

        private readonly Character.CharacterInfo _characterInfo;      
              

    
        public CharacterPresenter(Character.CharacterInfo characterInfo,CharacterLevelData characterLevelData, CharacterLevel characterLevel)
        {
            _characterInfo = characterInfo;           
           
            ExperiencePresenter = new CharacterExperiencePresenter(characterLevel);
            InfoPresenter = new CharacterInfoPresenter(characterLevelData);
            StatsPresenter = new CharacterStatsPresenter(characterInfo, characterLevelData, characterLevel);
        }

     
    }
}



