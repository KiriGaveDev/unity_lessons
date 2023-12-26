using Character;
using System.Collections.Generic;
using UnityEngine;


namespace Presenter.CharacterPresenter
{
    public class CharacterPresenter : ICharacterPresenter
    {
        public string UserName { get; }

        public string Description { get; }      

        public Sprite Icon { get; }        

        public HashSet<CharacterStat> CharacterStats => _characterInfo.Stats;

        public ICharacterExperiencePresenter ExperiencePresenter { get; }

        private readonly Character.CharacterInfo _characterInfo;
        private readonly CharacterLevelData _characterLevelData;
        

    
        public CharacterPresenter(Character.CharacterInfo characterInfo, CharacterLevelData characterLevelData, CharacterLevel characterLevel)
        {
            _characterInfo = characterInfo;
            _characterLevelData = characterLevelData;

            UserName = _characterLevelData.CharacterLevelSettings.userName;
            Description = _characterLevelData.CharacterLevelSettings.descritrion;
            Icon = _characterLevelData.CharacterLevelSettings.icon;

            ExperiencePresenter = new CharacterExperiencePresenter(characterLevel);

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



