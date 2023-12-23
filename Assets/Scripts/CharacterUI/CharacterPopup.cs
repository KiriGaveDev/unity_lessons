using Character;
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
            CreateStatsView(_characterPresenter.CharacterStats);
            gameObject.SetActive(true);
            closeButton.onClick.AddListener(Hide);
            _characterPresenter.OnExperienceChanged += CharacterPresenter_OnExperienceChanged;
            _characterPresenter.OnLevelUp += CharacterPresenter_OnLevelUp;
        }


        private void Hide()
        {
            gameObject.SetActive(false);
            closeButton.onClick.RemoveListener(Hide);
            _characterPresenter.OnExperienceChanged -= CharacterPresenter_OnExperienceChanged;
            _characterPresenter.OnLevelUp -= CharacterPresenter_OnLevelUp;
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
                CharacterStatView stat = Instantiate(characterStatViewPrefab, statsParent);
                stat.Initialize(characterStat.Name, characterStat.Value);
                _characterStats.Add(stat);
            }
        }


        private void AddExperience(int value)
        {
            expereinceSlider.value = value;
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
        #endregion



        #region Enents Heandler
        private void CharacterPresenter_OnExperienceChanged(int changedValue)
        {
            AddExperience(changedValue);
        }


        private void CharacterPresenter_OnLevelUp()
        {
            SetLevelView(_characterPresenter.Level);
            SetExperienceValue(_characterPresenter.CurrentExperience, _characterPresenter.RequiredExperience, 0);
            CreateStatsView(_characterPresenter.CharacterStats);            
        }

        #endregion
    }
}

