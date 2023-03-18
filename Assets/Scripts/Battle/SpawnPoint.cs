using UnityEngine;

namespace Battle
{
    public class SpawnPoint : MonoBehaviour
    {
        public Vector3 Position => _transform.position;
        public Quaternion Rotation => _transform.rotation;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }
    }
}