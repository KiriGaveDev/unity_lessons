using Character;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CharacterUI
{
    public class CharacterPopup : MonoBehaviour, IInitializable, IDisposable
    {
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

        private CharacterLevel _playerLevel;
        private UserInfo _userInfo;
        private Character.CharacterInfo _characterInfo;




        #region Public Methods
        [Inject]
        public void Construct(CharacterLevel playerLevel, UserInfo userInfo, Character.CharacterInfo characterInfo)
        {
            _playerLevel = playerLevel;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
        }


        public void Initialize()
        {
            SetExperienceValue(_playerLevel.CurrentExperience, _playerLevel.RequiredExperience, 0);
            SetLevelView();

            _playerLevel.OnExperienceChanged += PlayerLevel_OnExperienceChanged;
            _playerLevel.OnLevelUp += PlayerLevel_OnLevelUp;
            _userInfo.OnNameChanged += UserInfo_OnNameChanged;
            _userInfo.OnDescriptionChanged += UserInfo_OnDescriptionChanged;
            _userInfo.OnIconChanged += UserInfo_OnIconChanged;
            _characterInfo.OnStatRemoved += CharacterInfo_OnStatRemoved;
            _characterInfo.OnStatAdded += CharacterInfo_OnStatAdded;

        }


        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= PlayerLevel_OnExperienceChanged;
            _playerLevel.OnLevelUp -= PlayerLevel_OnLevelUp;
            _userInfo.OnNameChanged -= UserInfo_OnNameChanged;
            _userInfo.OnDescriptionChanged -= UserInfo_OnDescriptionChanged;
            _userInfo.OnIconChanged -= UserInfo_OnIconChanged;
            _characterInfo.OnStatRemoved -= CharacterInfo_OnStatRemoved;
            _characterInfo.OnStatAdded -= CharacterInfo_OnStatAdded;
        }

        #endregion



        #region Private Methods
        private void SetExperienceValue(int current, int target, int changedValue)
        {
            expereinceSlider.maxValue = target;
            expereinceSlider.value = current;

            experienceTxt.text = $"XP : {current} / {target}";
        }


        private void SetLevelView()
        {
            levelTxt.text = $"Level {_playerLevel.CurrentLevel}";
        }


        private void SetUserName()
        {
            nameTxt.text = _userInfo.Name;
        }


        private void SetUserDecription()
        {
            descriptionTxt.text = _userInfo.Description;
        }


        private void SetUserIcon()
        {
            characterIcon.sprite = _userInfo.Icon;
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
        private void PlayerLevel_OnExperienceChanged(int changedValue)
        {
            SetExperienceValue(_playerLevel.CurrentExperience, _playerLevel.RequiredExperience, changedValue);
        }


        private void PlayerLevel_OnLevelUp()
        {
            SetLevelView();
            SetExperienceValue(_playerLevel.CurrentExperience, _playerLevel.RequiredExperience, 0);
        }


        private void UserInfo_OnNameChanged(string userName)
        {
            SetUserName();
        }


        private void UserInfo_OnIconChanged(Sprite obj)
        {
            SetUserIcon();
        }


        private void UserInfo_OnDescriptionChanged(string obj)
        {
            SetUserDecription();
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
