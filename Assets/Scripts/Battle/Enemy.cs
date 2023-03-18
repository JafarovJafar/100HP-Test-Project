using System;
using UnityEngine;
using Battle.Enemies;

namespace Battle
{
    public class Enemy : MonoBehaviour, IPoolable, IDamageable, IDestroyable
    {
        public event Action Destroyed;
        public event Action<float> TakenDamage;

        public bool IsActive => _gameObject.activeSelf;

        [SerializeField] private EnemyVars _vars;

        private StateMachine _stateMachine;

        private GameObject _gameObject;
        private Transform _transform;

        public void Activate()
        {
            _gameObject.SetActive(true);
            ChangeDefaultState();
        }

        public void DeActivate()
        {
            _gameObject.SetActive(false);
        }

        public void SetParent(Transform parent) => _transform.parent = parent;
        public void SetPosition(Vector3 position) => _transform.position = position;
        public void SetRotation(Quaternion rotation) => _transform.rotation = rotation;

        public void TakeDamage(float damage)
        {

        }

        public void Destroy()
        {

        }

        private void ChangeDefaultState() => _stateMachine.ChangeState(new EnemyDefaultState(_vars));

        private void Update() => _stateMachine.Tick();
        private void FixedUpdate() => _stateMachine.FixedTick();

        private void OnDisable()
        {
            //@TODO сброс переменных
        }

        private void Awake()
        {
            _gameObject = gameObject;
            _transform = transform;
        }
    }
}