using Game_Input;
using System;


namespace Character
{
    public class CharacterAttackController : IDisposable, GameListener.IStartListener, GameListener.IFinishListener
    {
        private readonly CharacterAttackAgent _characterAttackAgent;
        private readonly IInputService _inputService;

        public CharacterAttackController(CharacterAttackAgent characterAttackComponent, IInputService inputService)
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
            _inputService.OnFire += Fire;
        }


        public void OnStart()
        {
            _inputService.OnFire -= Fire;
        }


        public void Fire()
        {
            _characterAttackAgent.Fire();
        }              
    }
}

