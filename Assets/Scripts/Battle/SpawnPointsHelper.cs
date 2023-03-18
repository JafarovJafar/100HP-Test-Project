using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class SpawnPointsHelper
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        public SpawnPoint GetRandom()
        {
            int random = Random.Range(0, _spawnPoints.Count);
            return _spawnPoints[random];
        }
    }
}