using Game;
using Game_Input;
using ShootEmUp;
using System;
using UnityEngine;
using Zenject;


namespace Character
{
    public sealed class CharacterMoveController :IDisposable, IStartListener, IFinishListener , IFixedUpdateListener 
    { 

        private readonly MoveComponent _characterMoveComponent;       
        private readonly IInputService _inputService;
        private Vector2 _direction;


        [Inject]
        public CharacterMoveController(IInputService inputService, MoveComponent characterMoveComponent, GameManager gameManager)
        {            
            _characterMoveComponent = characterMoveComponent;
            gameManager.AddListener(this);
            _inputService = inputService;
        }


        public void OnFixedUpdate(float fixedDeltaTime)
        {            
            _characterMoveComponent.Move(new Vector2(_direction.x, 0) * fixedDeltaTime);
        }
        

        public void Dispose()
        {
            _inputService.OnMove -= OnMove;
        }


        public void OnStart()
        {          
            _inputService.OnMove += OnMove;
        }


        private void OnMove(Vector2 moveDirection)
        {
           _direction = moveDirection;
        }


        public void OnFinish()
        {
            _inputService.OnMove -= OnMove;
        }
    }
}