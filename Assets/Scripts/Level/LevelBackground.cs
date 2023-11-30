using System;
using UnityEngine;
using static GameListener;

namespace ShootEmUp
{
 
    public sealed class LevelBackground : MonoBehaviour, IFixedUpdateListener
    {
        [Serializable]
        public sealed class Params
        {
            public float startPositionY;
            public float endPositionY;
            public float movingSpeedY;
        }

        [SerializeField] private Params parameters;

        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;

        private Transform myTransform;

      

        private void Awake()
        {
            startPositionY = parameters.startPositionY;
            endPositionY = parameters.endPositionY;
            movingSpeedY = parameters.movingSpeedY;
            myTransform = transform; 

            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }
              

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(positionX, startPositionY, positionZ);
            }

            myTransform.position -= new Vector3(positionX, movingSpeedY * Time.fixedDeltaTime, positionZ);
        }
    }
}