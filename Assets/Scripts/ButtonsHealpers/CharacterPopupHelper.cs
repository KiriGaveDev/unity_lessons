using Character;
using CharacterUI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace ButtonsHelpers
{
    public class CharacterPopupHelper : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button buttonOpenPopup;
        [SerializeField] private Button addExpereince;

        [SerializeField] private CharacterPopup characterPopup;
        [SerializeField] private CharacterLevelData characterLevelData;

        private CharacterLevel _playerLevel;       
        private Character.CharacterInfo _characterInfo;



        [Inject]
        public void Construct(CharacterLevel playerLevel, UserInfo userInfo, Character.CharacterInfo characterInfo)
        {
            _playerLevel = playerLevel;           
            _characterInfo = characterInfo;
        }


        public void Initialize()
        {
            buttonOpenPopup.onClick.AddListener(ButtonOpenPopup_OnClick);
            addExpereince.onClick.AddListener(AddExpereince_OnClick);
        }


        public void Dispose()
        {
            buttonOpenPopup.onClick.RemoveListener(ButtonOpenPopup_OnClick);
            addExpereince.onClick.RemoveListener(AddExpereince_OnClick);
        }


        private void ButtonOpenPopup_OnClick()
        {
            var characterPresenter = new CharacterPresenter(_playerLevel, _characterInfo, characterLevelData);
            characterPopup.Show(characterPresenter);
        }


        private void AddExpereince_OnClick()
        {
            _playerLevel.AddExperience(50);
            TryLevelUp();
        }


        private void TryLevelUp()
        {
            _playerLevel.LevelUp();
        }
    }
}
