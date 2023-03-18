using System.Collections.Generic;
using UnityEngine;
using Battle.Enemies;

namespace Battle
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnPointsHelper _spawnPointsHelper;
        
        public Enemy LastSpawnedEnemy => _lastSpawnedEnemy;
        public List<Enemy> SpawnedEnemies => _spawnedEnemies;

        private Enemy _lastSpawnedEnemy;

        private List<Enemy> _spawnedEnemies;

        private EnemiesFactory _factory;

        private Transform _transform;
        
        public void Init(EnemiesFactory factory)
        {
            _transform = transform;
            
            _factory = factory;
        }

        public void Activate()
        {

        }

        public void DeActivate()
        {

        }

        private void SpawnEnemy()
        {
            SpawnPoint spawnPoint = _spawnPointsHelper.GetRandom();
            
            Enemy enemy = _factory.GetRandom();
            enemy.SetPosition(spawnPoint.Position);
            enemy.SetRotation(spawnPoint.Rotation);
        }
    }
}