using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(TrailRenderer))]
    public class Trail : MonoBehaviour
    {
        private GameObject _gameObject;
        private TrailRenderer _trailRenderer;

        public void Activate()
        {
            _trailRenderer.enabled = true;
            _gameObject.SetActive(true);
        }

        public void DeActivate()
        {
            _trailRenderer.enabled = false;
            _gameObject.SetActive(false);
        }

        private void Awake()
        {
            _gameObject = gameObject;
            _trailRenderer = GetComponent<TrailRenderer>();
        }
    }
}