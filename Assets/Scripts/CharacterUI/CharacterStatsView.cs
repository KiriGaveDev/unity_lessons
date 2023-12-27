using Character;
using Presenter;
using Presenter.CharacterPresenter;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterUI
{
    public class CharacterStatsView : MonoBehaviour
    {
        [SerializeField] private Transform _statsParent;
        [SerializeField] private CharacterStatView _characterStatViewPrefab;

        private readonly List<CharacterStatView> _characterStats = new();

        private ICharacterStatsPresenter _statsPresenter;

        public void Show(IPresenter presenter)
        {
            if (presenter is not ICharacterStatsPresenter statsPresenter)
            {
                throw new Exception($"Invalid presenter type. Expected {nameof(ICharacterStatsPresenter)}.");
            }

            _statsPresenter = statsPresenter;

            CreateStatsView(_statsPresenter.CharacterStats);

            _statsPresenter.OnLevelUp += StatsPresenter_OnLevelUp;
        }

        

        private void CreateStatsView(HashSet<CharacterStat> characterStats)
        {
            foreach (CharacterStatView statsView in _characterStats)
            {
                Destroy(statsView.gameObject);
            }

            _characterStats.Clear();

            foreach (CharacterStat characterStat in characterStats)
            {
                CharacterStatView stat = Instantiate(_characterStatViewPrefab, _statsParent);
                stat.Initialize(characterStat.Name, characterStat.Value);
                _characterStats.Add(stat);
            }
        }

        private void StatsPresenter_OnLevelUp()
        {
            CreateStatsView(_statsPresenter.CharacterStats);
        }
    }

}
