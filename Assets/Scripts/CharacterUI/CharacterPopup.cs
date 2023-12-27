using Character;
using Presenter;
using Presenter.CharacterPresenter;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CharacterUI
{
    public class CharacterPopup : MonoBehaviour
    {    
        [SerializeField] private CharacterExperienceView _experienceView;
        [SerializeField] private CharacterInfoView _infoView;

        [SerializeField] private Button _closeButton;

        [Header("Stat prefab ref")]
        [SerializeField] private Transform _statsParent;
        [SerializeField] private CharacterStatView _characterStatViewPrefab;

        private readonly List<CharacterStatView> _characterStats = new();


        private ICharacterPresenter _characterPresenter;    


        public void Show(IPresenter presenter)
        {
            if (presenter is not ICharacterPresenter characterPresenter)
            {
                throw new Exception($"Invalid presenter type. Expected {nameof(ICharacterPresenter)}.");
            }

            _characterPresenter = characterPresenter;

            _experienceView.Show(_characterPresenter.ExperiencePresenter);
            _infoView.Show(_characterPresenter.CharacterInfoPresenter);
            
            CreateStatsView(_characterPresenter.CharacterStats);
            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(Hide);          
        }
        

        private void Hide()
        {
            gameObject.SetActive(false);
            _closeButton.onClick.RemoveListener(Hide);           
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
    }
}

