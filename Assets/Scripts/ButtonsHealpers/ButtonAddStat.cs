using Character;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace ButtonsHelpers
{
    public class ButtonAddStat : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button button;
        [SerializeField] private string statName;
        [SerializeField] private int defaultStatValue;

        private Character.CharacterInfo _characterInfo;


        [Inject]
        public void Construct(Character.CharacterInfo characterInfo)
        {
            _characterInfo = characterInfo;
        }


        public void Initialize()
        {
            button.onClick.AddListener(OnClick);
        }


        public void Dispose()
        {
            button.onClick.RemoveListener(OnClick);
        }


        private void OnClick()
        {
            _characterInfo.AddStat(new CharacterStat(statName, defaultStatValue)) ;
        }
    }
}