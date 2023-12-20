using Character;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace ButtonsHelpers
{
    public class ButtonChangeIcon : MonoBehaviour, IInitializable, IDisposable
    {
        [SerializeField] private Button button;
        [SerializeField] private List<Sprite> icons = new List<Sprite>();

        private UserInfo _userInfo;


        [Inject]
        public void Construct(UserInfo playerLevel)
        {
            _userInfo = playerLevel;
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
            _userInfo.ChangeIcon(GetRamdomSprite());
        }


        private Sprite GetRamdomSprite()
        {
            return icons[UnityEngine.Random.Range(0, icons.Count)];
        }
    }
}