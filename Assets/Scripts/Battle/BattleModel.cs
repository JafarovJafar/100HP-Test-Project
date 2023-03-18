using System;
using UnityEngine;

namespace Battle
{
    public class BattleModel : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField] private HeroBase _heroBase;
        [SerializeField] private EnemiesFactory _enemiesFactory;
        [SerializeField] private EnemiesSpawner _enemiesSpawner;

        public void Init()
        {
            _heroBase.Init();
            _heroBase.Destroyed += HeroBase_Destroyed;

            _enemiesFactory.Init(_heroBase);
            _enemiesSpawner.Init(_enemiesFactory);

            _enemiesSpawner.Activate();
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