using System;
using UnityEngine;


namespace Game_Input
{
    public interface IInputService
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;
    }
}
