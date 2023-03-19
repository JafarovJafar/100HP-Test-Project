using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemiesSpawner : MonoBehaviour
    {
        public event Action<IEnemy> EnemySpawned; 

        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private SpawnPointsHelper _spawnPointsHelper;

        public List<IEnemy> SpawnedEnemies => _spawnedEnemies;

        private float _lastSpawnTime;

        private List<IEnemy> _spawnedEnemies = new List<IEnemy>();

        private IEnemyFactory _factory;

        public void Init(IEnemyFactory factory)
        {
            _factory = factory;
        }

        public void Activate()
        {
            enabled = true;
        }

        public void DeActivate()
        {
            enabled = false;
        }

        public void ReleaseAllEnemies()
        {
            for (int i = _spawnedEnemies.Count - 1; i >= 0; i--)
            {
                _spawnedEnemies[i].Destroy();
            }
        }

        private void SpawnEnemy()
        {
            (Vector3 position, Quaternion rotation) = _spawnPointsHelper.GetRandomPoint();

            IEnemy enemy = _factory.GetRandom();
            enemy.SetPosition(position);
            enemy.SetRotation(rotation);
            enemy.Destroyed += Enemy_Destroyed;
            _spawnedEnemies.Add(enemy);
            EnemySpawned?.Invoke(enemy);
        }

        private void Enemy_Destroyed(IDestroyable enemy)
        {
            enemy.Destroyed -= Enemy_Destroyed;
            _spawnedEnemies.Remove(enemy as IEnemy);
        }

        private void Update()
        {
            if (Time.time > _lastSpawnTime + _spawnInterval)
            {
                SpawnEnemy();
                _lastSpawnTime = Time.time;
            }
        }
    }
}