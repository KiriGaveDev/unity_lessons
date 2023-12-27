using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Presenter.CharacterPresenter
{
    public sealed class CharacterStatsPresenter : ICharacterStatsPresenter
    {
        public HashSet<CharacterStat> CharacterStats => _characterInfo.Stats;

        private readonly Character.CharacterInfo _characterInfo;
        private readonly CharacterLevelData _characterLevelData;
        private readonly CharacterLevel _characterLevel;


        public CharacterStatsPresenter(Character.CharacterInfo characterInfo, CharacterLevelData characterLevelData, CharacterLevel characterLevel)
        {
            _characterInfo = characterInfo;
            _characterLevelData = characterLevelData;       
            _characterLevel = characterLevel;

            SetCharacterStats();
        }


        public void SetCharacterStats()
        {
            var stats = _characterLevelData.GetCharacterStats();

            for (int i = 0; i < stats.Count; i++)
            {
                var statName = stats[i].nameStat;
                var statValue = _characterLevelData.GetValueByLevel(statName, _characterLevel.CurrentLevel);
                _characterInfo.AddStat(new CharacterStat(statName, statValue)) ;
            }
        }     
    }
}

