using UnityEngine;
using Battle.Projectiles;

namespace Battle
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private ProjectileVars _vars;

        public bool IsActive => _gameObject.activeSelf;

        private float _strength;

        private StateMachine _stateMachine;

        private GameObject _gameObject;
        private Transform _transform;

        public void SetStrength(float strength) => _strength = strength;

        public void Activate()
        {
            _gameObject.SetActive(true);

            ChangeFlyState();
        }

        public void DeActivate() => _gameObject.SetActive(false);

        public void SetParent(Transform parent) => _transform.SetParent(parent);

        public void SetPosition(Vector3 position) => _transform.position = position;
        public void SetRotation(Quaternion rotation) => _transform.rotation = rotation;

        private void ChangeFlyState() => _stateMachine.ChangeState(new ProjectileFlyState(_vars));

        private void Awake()
        {
            _gameObject = gameObject;
            _transform = transform;
        }
    }
}