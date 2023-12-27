using Presenter;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterUI
{
    public sealed class CharacterInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _userNameTxt;
        [SerializeField] private TextMeshProUGUI _descriptionTxt;
        [SerializeField] private Image _icon;

        private ICharacterInfoPresenter _characterInfoPresenter;


        public void Show(IPresenter presenter)
        {
            if(presenter is not ICharacterInfoPresenter characterInfoPresenter)
            {
                throw new Exception($"Invalid presenter type. Expected {nameof(ICharacterInfoPresenter)}.");
            }

            _characterInfoPresenter = characterInfoPresenter;

            _userNameTxt.text = _characterInfoPresenter.Name;
            _descriptionTxt.text = _characterInfoPresenter.Description;
            _icon.sprite = _characterInfoPresenter.Icon;
        }
    }
}

