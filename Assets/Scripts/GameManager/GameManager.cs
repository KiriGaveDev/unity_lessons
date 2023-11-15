using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            CharacterController.OnCharacterDied += CharacterController_OnCharacterDied;
        }      


        private void OnDisable()
        {
            CharacterController.OnCharacterDied -= CharacterController_OnCharacterDied;
        }


        private void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }


        private void CharacterController_OnCharacterDied()
        {
            FinishGame();
        }
    }
}