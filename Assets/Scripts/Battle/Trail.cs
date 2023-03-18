using UnityEngine;

namespace Battle
{
    public class Trail : MonoBehaviour
    {
        private GameObject _gameObject;

        public void Activate() => _gameObject.SetActive(true);
        public void DeActivate() => _gameObject.SetActive(false);

        private void Awake()
        {
            _gameObject = gameObject;
        }
    }
}