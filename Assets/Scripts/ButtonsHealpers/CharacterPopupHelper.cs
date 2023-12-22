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
        [SerializeField] private CharacterPopup characterPopup;
        [SerializeField] private CharacterLevelData characterLevelData;

        private CharacterLevel _playerLevel;
        private UserInfo _userInfo;
        private Character.CharacterInfo _characterInfo;



        [Inject]
        public void Construct(CharacterLevel playerLevel, UserInfo userInfo, Character.CharacterInfo characterInfo)
        {
            _playerLevel = playerLevel;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
        }


        public void Initialize()
        {
            buttonOpenPopup.onClick.AddListener(OnClick);
        }


        public void Dispose()
        {
            buttonOpenPopup.onClick.RemoveListener(OnClick);
        }


        private void OnClick()
        {
            var characterPresenter = new CharacterPresenter(_playerLevel, _userInfo, _characterInfo, characterLevelData);
            characterPopup.Show(characterPresenter);
        }
    }
}
