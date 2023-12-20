using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ButtonsHelpers
{
    public class ButtonRemoveStat : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button button;
        [SerializeField] private string statName;

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
            _characterInfo.RemoveStat(_characterInfo.GetStat(statName));
        }
    }
}