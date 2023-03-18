using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(TrailRenderer))]
    public class Trail : MonoBehaviour
    {
        private GameObject _gameObject;
        private TrailRenderer _trailRenderer;

        public void Activate() => _gameObject.SetActive(true);
        public void DeActivate() => _gameObject.SetActive(false);

        private void Awake()
        {
            _gameObject = gameObject;
            _trailRenderer = GetComponent<TrailRenderer>();
        }
    }
}