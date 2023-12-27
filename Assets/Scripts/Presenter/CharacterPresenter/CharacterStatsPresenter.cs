using Character;
using System;
using System.Collections.Generic;


namespace Presenter.CharacterPresenter
{
    public sealed class CharacterStatsPresenter : ICharacterStatsPresenter, IDisposable
    {
        public event Action OnLevelUp;

        public HashSet<CharacterStat> CharacterStats => _characterInfo.Stats;

        private readonly CharacterInfo _characterInfo;
        private readonly CharacterLevelData _characterLevelData;
        private readonly CharacterLevel _characterLevel;



        public CharacterStatsPresenter(CharacterInfo characterInfo, CharacterLevelData characterLevelData, CharacterLevel characterLevel)
        {
            _characterInfo = characterInfo;
            _characterLevelData = characterLevelData;
            _characterLevel = characterLevel;

            SetCharacterStats();
            _characterLevel.OnLevelUp += CharacterLevel_OnLevelUp;
        }


        public void SetCharacterStats()
        {
            var stats = _characterLevelData.GetCharacterStats();

            for (int i = 0; i < stats.Count; i++)
            {
                var statName = stats[i].nameStat;
                var statValue = _characterLevelData.GetValueByLevel(statName, _characterLevel.CurrentLevel);
                _characterInfo.AddStat(new CharacterStat(statName, statValue));
            }
        }


        private void CharacterLevel_OnLevelUp()
        {
            foreach (var stat in CharacterStats)
            {
                stat.ChangeValue(_characterLevelData.GetValueByLevel(stat.Name, _characterLevel.CurrentLevel));
            }

            OnLevelUp?.Invoke();
        }


        public void Dispose()
        {
            _characterLevel.OnLevelUp -= CharacterLevel_OnLevelUp;
        }
    }
}

