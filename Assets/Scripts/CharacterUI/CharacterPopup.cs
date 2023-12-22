using Character;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CharacterUI
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private Button closeButton;

        [Header("Experience")]
        [SerializeField] private Slider expereinceSlider;
        [SerializeField] private TextMeshProUGUI experienceTxt;
        [SerializeField] private TextMeshProUGUI levelTxt;

        [Header("User Info")]
        [SerializeField] private TextMeshProUGUI nameTxt;
        [SerializeField] private TextMeshProUGUI descriptionTxt;
        [SerializeField] private Image characterIcon;

        [Header("Stat prefab ref")]
        [SerializeField] private Transform statsParent;
        [SerializeField] private CharacterStatView characterStatViewPrefab;

        private readonly List<CharacterStatView> _characterStats = new();
          

        private ICharacterPresenter _characterPresenter;


        public void Show(IPresenter presenter)
        {          
            if (presenter is not ICharacterPresenter characterPresenter)
            {
                Debug.LogError("fail");
                return;
            }

            
            _characterPresenter = characterPresenter;
            nameTxt.text = _characterPresenter.UserName;


            SetExperienceValue(_characterPresenter.CurrentExperience, _characterPresenter.RequiredExperience, 0);
            SetLevelView(_characterPresenter.Level);
            SetUserName(_characterPresenter.UserName);
            SetUserDecription(_characterPresenter.Description);
            SetUserIcon(_characterPresenter.Icon);
            gameObject.SetActive(true);
            closeButton.onClick.AddListener(Hide);
            _characterPresenter.OnExperienceChanged += CharacterPresenter_OnExperienceChanged;
        }


        #region Public Methods




        #endregion
        private void Hide()
        {
            gameObject.SetActive(false);
            closeButton.onClick.RemoveListener(Hide);
            _characterPresenter.OnExperienceChanged -= CharacterPresenter_OnExperienceChanged;
        }


        private void AddExperience(int value)
        {           
            expereinceSlider.value += value;
            experienceTxt.text = $"XP : {expereinceSlider.value} / {expereinceSlider.maxValue}";
        }


        #region Private Methods
        private void SetExperienceValue(int current, int target, int changedValue)
        {
            expereinceSlider.maxValue = target;
            expereinceSlider.value = current;

            experienceTxt.text = $"XP : {current} / {target}";
        }


        private void SetLevelView(int level)
        {
            levelTxt.text = $"Level {level}";
        }


        private void SetUserName(string userName)
        {
            nameTxt.text = userName;
        }


        private void SetUserDecription(string description)
        {
            descriptionTxt.text = description;
        }


        private void SetUserIcon(Sprite icon)
        {
            characterIcon.sprite = icon;
        }


        private void AddStat(CharacterStat characterStat)
        {
            CharacterStatView stat = Instantiate(characterStatViewPrefab, statsParent);
            stat.Initialize(characterStat.Name, characterStat.Value);
            _characterStats.Add(stat);
            characterStat.OnValueChanged += stat.SetValue;
        }


        private void RemoveStat(CharacterStat characterStat)
        {
            CharacterStatView stat = GetStat(characterStat.Name);
            _characterStats.Remove(stat);
            characterStat.OnValueChanged -= stat.SetValue;
            Destroy(stat.gameObject);
        }


        private CharacterStatView GetStat(string statName)
        {
            foreach (CharacterStatView stat in _characterStats)
            {
                if (stat.StatName == statName)
                {
                    return stat;
                }
            }

            return null;
        }
        #endregion



        #region Enents Heandler
        private void CharacterPresenter_OnExperienceChanged(int changedValue)
        {
            AddExperience(changedValue);
        }


        private void PlayerLevel_OnLevelUp()
        {
           // SetLevelView();
      //      SetExperienceValue(_playerLevel.CurrentExperience, _playerLevel.RequiredExperience, 0);
        }


        private void UserInfo_OnNameChanged(string userName)
        {
         //   SetUserName();
        }


        private void UserInfo_OnIconChanged(Sprite obj)
        {
           // SetUserIcon();
        }


        private void UserInfo_OnDescriptionChanged(string obj)
        {
           // SetUserDecription();
        }


        private void CharacterInfo_OnStatAdded(CharacterStat characterStat)
        {
            AddStat(characterStat);
        }


        private void CharacterInfo_OnStatRemoved(CharacterStat characterStat)
        {
            RemoveStat(characterStat);
        }
        #endregion
    }

}
