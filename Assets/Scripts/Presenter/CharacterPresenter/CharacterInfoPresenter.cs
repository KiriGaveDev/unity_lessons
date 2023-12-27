using UnityEngine;

namespace Presenter.CharacterPresenter
{
    public class CharacterInfoPresenter : ICharacterInfoPresenter
    {
        public string Name => _characterLevelData.CharacterLevelSettings.userName;

        public string Description => _characterLevelData.CharacterLevelSettings.descritrion;

        public Sprite Icon => _characterLevelData.CharacterLevelSettings.icon;

        
        private readonly CharacterLevelData _characterLevelData;


        public CharacterInfoPresenter(CharacterLevelData characterLevelData)
        {          
            _characterLevelData = characterLevelData;        
        }       
    }
}
