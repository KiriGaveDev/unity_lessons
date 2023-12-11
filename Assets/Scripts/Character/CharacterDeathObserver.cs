using Game;
using ShootEmUp;
using System;
using UnityEngine;
using Zenject;


namespace Character
{
    public class CharacterDeathObserver : IDisposable, IStartListener, IFinishListener
    {
        private readonly HitPointsComponent _characterHitsComponent;
        private readonly GameManager _gameManager;


        [Inject]
        public CharacterDeathObserver(GameManager gameManager, HitPointsComponent characterHitsComponent)
        {
            _characterHitsComponent = characterHitsComponent;
            _gameManager = gameManager;
        }


        private void OnCharacterDied(GameObject gameObject)
        {
            _gameManager.OnFinished();
        }

       
        public void Dispose()
        {
            _characterHitsComponent.OnHpEmpty -= OnCharacterDied;
        }


        public void OnStart()
        {
            _characterHitsComponent.OnHpEmpty += OnCharacterDied;
        }


        public void OnFinish()
        {
            _characterHitsComponent.OnHpEmpty -= OnCharacterDied;
        }
    }

}
