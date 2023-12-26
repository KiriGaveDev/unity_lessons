using Character;
using Presenter;
using Presenter.CharacterPresenter;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CharacterUI
{
    public class CharacterPopup : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        [Header("Experience")]
        [SerializeField] private CharacterExperienceView _experienceView;
        

        [Header("User Info")]
        [SerializeField] private TextMeshProUGUI _nameTxt;
        [SerializeField] private TextMeshProUGUI _descriptionTxt;
        [SerializeField] private Image _characterIcon;

        [Header("Stat prefab ref")]
        [SerializeField] private Transform _statsParent;
        [SerializeField] private CharacterStatView _characterStatViewPrefab;

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
            _nameTxt.text = _characterPresenter.UserName;

            _experienceView.Show(_characterPresenter.ExperiencePresenter);
            SetUserName(_characterPresenter.UserName);
            SetUserDecription(_characterPresenter.Description);
            SetUserIcon(_characterPresenter.Icon);
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

        #region Private Methods
     

        private void SetUserName(string userName)
        {
            _nameTxt.text = userName;
        }


        private void SetUserDecription(string description)
        {
            _descriptionTxt.text = description;
        }


        private void SetUserIcon(Sprite icon)
        {
            _characterIcon.sprite = icon;
        }
        #endregion       
    }
}

