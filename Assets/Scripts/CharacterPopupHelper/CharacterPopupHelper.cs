using Character;
using CharacterUI;
using Presenter.CharacterPresenter;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace CharacterPopupHelper
{
    public class CharacterPopupHelper : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button _buttonOpenPopup;
        [SerializeField] private Button _buttonAddExpereince;
        [SerializeField] private Button _buttonLevelUp;
        
        [SerializeField] private CharacterPopup _characterPopup;
        [SerializeField] private CharacterLevelData _characterLevelData;

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
            _buttonOpenPopup.onClick.AddListener(ButtonOpenPopup_OnClick);
            _buttonAddExpereince.onClick.AddListener(ButtonAddExpereince_OnClick);
            _buttonLevelUp.onClick.AddListener(ButtonLevelUp_OnClick);
        }
                

        public void Dispose()
        {
            _buttonOpenPopup.onClick.RemoveListener(ButtonOpenPopup_OnClick);
            _buttonAddExpereince.onClick.RemoveListener(ButtonAddExpereince_OnClick);
            _buttonLevelUp.onClick.RemoveListener(ButtonLevelUp_OnClick);
        }


        private void ButtonOpenPopup_OnClick()
        {
            var characterPresenter = new CharacterPresenter(_characterInfo, _characterLevelData, _playerLevel);         
            _characterPopup.Show(characterPresenter);           
        }


        private void ButtonAddExpereince_OnClick()
        {
            _playerLevel.AddExperience(50);           
        }


        private void TryLevelUp()
        {
            _playerLevel.LevelUp();
        }


        private void ButtonLevelUp_OnClick()
        {
            TryLevelUp();
        }
    }
}
