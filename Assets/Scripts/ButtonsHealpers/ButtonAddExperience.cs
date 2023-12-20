using Character;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace ButtonsHelpers
{
    public class ButtonAddExperience : MonoBehaviour, IInitializable
    {
        [SerializeField] private int addedValue;
        [SerializeField] private Button button;

        private CharacterLevel playerLevel;


        [Inject]
        public void Construct(CharacterLevel playerLevel)
        {
            this.playerLevel = playerLevel;
        }


        public void Initialize()
        {
            button.onClick.AddListener(OnClick);
        }


        private void OnClick()
        {
            playerLevel.AddExperience(addedValue);
        }
    }

}
