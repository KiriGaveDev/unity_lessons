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
        [SerializeField] private CharacterStatsView _statsView;

        [SerializeField] private Button _closeButton;

        


        private ICharacterPresenter _characterPresenter;    


        public void Show(IPresenter presenter)
        {
            if (presenter is not ICharacterPresenter characterPresenter)
            {
                throw new Exception($"Invalid presenter type. Expected {nameof(ICharacterPresenter)}.");
            }

            _characterPresenter = characterPresenter;

            _experienceView.Show(_characterPresenter.ExperiencePresenter);
            _infoView.Show(_characterPresenter.InfoPresenter);
            _statsView.Show(_characterPresenter.StatsPresenter);

            gameObject.SetActive(true);
            _closeButton.onClick.AddListener(Hide);          
        }
        

        private void Hide()
        {
            gameObject.SetActive(false);
            _closeButton.onClick.RemoveListener(Hide);           
        }
        
    }
}

