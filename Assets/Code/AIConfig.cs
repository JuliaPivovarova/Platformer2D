using System;
using UnityEngine;

namespace Code
{
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanseToTarget;
        public Transform[] wayPoints;
    }
}