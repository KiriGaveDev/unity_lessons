using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Input
{
    public class KeyboardInput : IInputService, GameListener.IUpdateListener
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;

        public void OnUpdate(float deltaTime)
        {
           if(Input.GetKeyDown(KeyCode.F)) 
            {
                OnFire?.Invoke();
            }


            OnMove?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
    }

}
