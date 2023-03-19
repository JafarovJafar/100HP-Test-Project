using System;
using UnityEngine;

namespace Battle
{
    public class BattleModel : MonoBehaviour, IBattleModel
    {
        public event Action Finished;

        [SerializeField] private HeroBase _heroBase;
        [SerializeField] private EnemiesFactory _enemiesFactory;
        [SerializeField] private EnemiesSpawner _enemiesSpawner;

        public IHero Hero => _heroBase;
        public IBalance Balance => _balance;

        private IBalance _balance;
        private IAudioManager _audioManager;

        public void Init(IBalance balance, IAudioManager audioManager)
        {
            _balance = balance;
            _audioManager = audioManager;

            _heroBase.Init();
            _heroBase.Destroyed += HeroBase_Destroyed;

            _enemiesFactory.Init(_heroBase);
            _enemiesSpawner.Init(_enemiesFactory);
            _enemiesSpawner.EnemySpawned += Enemy_Spawned;

            _enemiesSpawner.Activate();
        }

        private void Enemy_Spawned(IEnemy enemy)
        {
            enemy.Destroyed += Enemy_Destroyed;
        }

        private void Enemy_Destroyed(IDestroyable destroyable)
        {
            destroyable.Destroyed -= Enemy_Destroyed;

            if (_heroBase.IsDestroyed) return;
            _balance.AddMoney((destroyable as IEnemy).Cost);
        }
        
        private void HeroBase_Destroyed(IDestroyable destroyable)
        {
            _enemiesSpawner.DeActivate();
            _enemiesSpawner.ReleaseAllEnemies();

            Finished?.Invoke();
        }

        private void Lose()
        {
            _enemiesSpawner.DeActivate();
            foreach (var enemy in _enemiesSpawner.SpawnedEnemies)
            {
                enemy.Destroy();
            }

            Finished?.Invoke();
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) Lose();
            else if (Input.GetKeyDown(KeyCode.D)) _heroBase.TakeDamage(1f);
        }
#endif
    }
}