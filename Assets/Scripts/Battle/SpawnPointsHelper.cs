using System;
using UnityEngine;

namespace Battle
{
    [Serializable]
    public class SpawnPointsHelper
    {
        public (Vector3, Quaternion) GetRandomPoint()
        {
            return (Vector3.one, Quaternion.identity);
        }
    }
}