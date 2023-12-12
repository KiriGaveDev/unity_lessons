using Game_Input;
using System;
using Zenject;


namespace Character
{
    public class CharacterAttackController : IDisposable, IStartListener, IFinishListener
    {
        private readonly IInputService _inputService;
        private readonly CharacterAttackAgent _characterAttackAgent;


        [Inject]
        public CharacterAttackController(IInputService inputService, CharacterAttackAgent characterAttackComponent)
        {          
            _inputService = inputService;
            _characterAttackAgent = characterAttackComponent;
        }


        public void Dispose()
        {
            _inputService.OnFire -= Fire;
        }


        public void OnFinish()
        {
            _inputService.OnFire -= Fire;
        }


        public void OnStart()
        {
            _inputService.OnFire += Fire;
        }


        public void Fire()
        {
            _characterAttackAgent.Fire();
        }              
    }
}

