using Character;
using System.Collections.Generic;
using UnityEngine;


namespace Presenter.CharacterPresenter
{
    public class CharacterPresenter : ICharacterPresenter
    {       
        public HashSet<CharacterStat> CharacterStats => _characterInfo.Stats;

        public ICharacterExperiencePresenter ExperiencePresenter { get; }

        public ICharacterInfoPresenter CharacterInfoPresenter { get; }


        private readonly Character.CharacterInfo _characterInfo;
        private readonly CharacterLevelData _characterLevelData;
              

    
        public CharacterPresenter(Character.CharacterInfo characterInfo,CharacterLevelData characterLevelData, CharacterLevel characterLevel)
        {
            _characterInfo = characterInfo;
          
            _characterLevelData = characterLevelData;
           
            ExperiencePresenter = new CharacterExperiencePresenter(characterLevel);
            CharacterInfoPresenter = new CharacterInfoPresenter(characterLevelData);

            AddStats();           
        }


        private void AddStats()
        {
            foreach (StatSettings starts in _characterLevelData.GetCharacterStats())
            {
              //  _characterInfo.AddStat(new CharacterStat(starts.nameStat, _characterLevelData.GetValueByLevel(starts.nameStat, Level)));
            }
        }


        private void UpdateStatsData()
        {
            foreach (CharacterStat stats in CharacterStats)
            {
              //  stats.ChangeValue(_characterLevelData.GetValueByLevel(stats.Name, Level));
            }
        }      
    }
}



