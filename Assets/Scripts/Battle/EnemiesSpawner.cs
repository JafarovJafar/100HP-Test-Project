using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private SpawnPointsHelper _spawnPointsHelper;
        
        public IEnemy LastSpawnedEnemy => _lastSpawnedEnemy;
        public List<IEnemy> SpawnedEnemies => _spawnedEnemies;

        private IEnemy _lastSpawnedEnemy;
        private float _lastSpawnTime;
        
        private List<IEnemy> _spawnedEnemies;

        private IEnemyFactory _factory;

        private Transform _transform;
        
        public void Init(IEnemyFactory factory)
        {
            _transform = transform;
            
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

        private void SpawnEnemy()
        {
            (Vector3 position, Quaternion rotation) = _spawnPointsHelper.GetRandomPoint();
            
            IEnemy enemy = _factory.GetRandom();
            enemy.SetPosition(position);
            enemy.SetRotation(rotation);
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