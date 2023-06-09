﻿using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemiesFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private List<Enemy> _enemiesPrefabs = new List<Enemy>();

        private IHero _hero;

        public void Init(IHero hero)
        {
            _hero = hero;
        }

        public IEnemy GetRandom()
        {
            int randomIndex = Random.Range(0, _enemiesPrefabs.Count);
            Enemy enemyPrefab = _enemiesPrefabs[randomIndex];
            
            Enemy enemy = MonoPool.Instance.Get(enemyPrefab);
            enemy.SetTarget(_hero);
            
            return enemy;
        }
    }
}