using Game;
using System;
using UnityEngine;


namespace Game_Input
{
    public class KeyboardInput : IInputService, IUpdateListener
    {          
        public event Action OnFire;
        public event Action<Vector2> OnMove;

        
        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {             
                OnFire?.Invoke();
            }

            OnMove?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }    
    }

}
