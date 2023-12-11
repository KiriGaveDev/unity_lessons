using System;
using UnityEngine;

namespace Level
{ 
    public sealed class LevelBackground : IFixedUpdateListener
    {
        [Serializable]
        public sealed class Params
        {
            public float startPositionY;
            public float endPositionY;
            public float movingSpeedY;
        }

      
        private readonly float _startPositionY;
        private readonly float _endPositionY;
        private readonly float _movingSpeedY;
        private readonly float _positionX;
        private readonly float _positionZ;

        private readonly Transform _background;

      

        public LevelBackground(Params parameters, Transform backGround)
        {
            _startPositionY = parameters.startPositionY;
            _endPositionY = parameters.endPositionY;
            _movingSpeedY = parameters.movingSpeedY;
            _background = backGround;

            Vector3 position = _background.position;
            _positionX = position.x;
            _positionZ = position.z;
        }
              

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (_background.position.y <=   _endPositionY)
            {
                _background.position = new Vector3(_positionX,  _startPositionY, _positionZ);
            }

            _background.position -= new Vector3(_positionX, _movingSpeedY * Time.fixedDeltaTime, _positionZ);
        }
    }
}