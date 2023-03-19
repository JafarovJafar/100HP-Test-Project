using System;
using UnityEngine;
using Battle.Projectiles;

namespace Battle
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private ProjectileVars _vars;

        public bool IsActive => _gameObject.activeSelf;

        private float _strength;

        private StateMachine _stateMachine = new StateMachine();

        private GameObject _gameObject;

        public void SetStrength(float strength) => _strength = strength;

        public void Activate()
        {
            _gameObject.SetActive(true);

            ChangeFlyState();
        }

        public void DeActivate() => _gameObject.SetActive(false);

        public void SetParent(Transform parent) => _vars.Transform.SetParent(parent);

        public void SetPosition(Vector3 position) => _vars.Transform.position = position;
        public void SetRotation(Quaternion rotation) => _vars.Transform.rotation = rotation;

        private void ChangeFlyState() => _stateMachine.ChangeState(new ProjectileFlyState(_vars, ChangeDestroyState));
        private void ChangeDestroyState() => _stateMachine.ChangeState(new ProjectileDieState(_vars, DeActivate));

        private void FixedUpdate() => _stateMachine.FixedTick();

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out IEnemy enemy))
            {
                enemy.TakeDamage(_strength);
                ChangeDestroyState();
            }
        }

        private void OnDisable()
        {
            _vars.RootGameObject.SetActive(true);
        }

        private void Awake()
        {
            _gameObject = gameObject;
            _vars.Transform = transform;
        }
    }
}