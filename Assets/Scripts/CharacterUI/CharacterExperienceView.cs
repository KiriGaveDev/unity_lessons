using Presenter;
using Presenter.CharacterPresenter;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterUI
{
    public sealed class CharacterExperienceView : MonoBehaviour
    {
        [SerializeField] private Slider _expereinceSlider;
        [SerializeField] private TextMeshProUGUI _experienceTxt;
        [SerializeField] private TextMeshProUGUI _levelTxt;

        private ICharacterExperiencePresenter _characterExperiencePresenter;


        public void Show(IPresenter presenter)
        {
            if (presenter is not ICharacterExperiencePresenter characterPresenter)
            {
                throw new Exception($"Invalid presenter type. Expected {nameof(ICharacterExperiencePresenter)}.");                
            }

            _characterExperiencePresenter = characterPresenter;

            SetExperienceValue(_characterExperiencePresenter.CurrentExperience, _characterExperiencePresenter.RequiredExperience, _characterExperiencePresenter.ExperienceText);
            SetLevelView(_characterExperiencePresenter.Level);

            _characterExperiencePresenter.OnExperienceChanged += CharacterPresenter_OnExperienceChanged;
            _characterExperiencePresenter.OnLevelUp += CharacterPresenter_OnLevelUp;
        }


        private void SetExperienceValue(int current, int target, string expText)
        {
            _expereinceSlider.maxValue = target;
            _expereinceSlider.value = current;

            _experienceTxt.text = expText;
        }


        private void SetLevelView(string levelText)
        {
            _levelTxt.text = levelText;
        }


        private void Hide()
        {
            _characterExperiencePresenter.OnExperienceChanged -= CharacterPresenter_OnExperienceChanged;
            _characterExperiencePresenter.OnLevelUp -= CharacterPresenter_OnLevelUp;
        }


        private void CharacterPresenter_OnExperienceChanged(int changedValue)
        {
            SetExperienceValue(_characterExperiencePresenter.CurrentExperience, _characterExperiencePresenter.RequiredExperience, _characterExperiencePresenter.ExperienceText);
        }


        private void CharacterPresenter_OnLevelUp()
        {
            SetLevelView(_characterExperiencePresenter.Level);
            SetExperienceValue(_characterExperiencePresenter.CurrentExperience, _characterExperiencePresenter.RequiredExperience, _characterExperiencePresenter.ExperienceText);
        }

    }
}
