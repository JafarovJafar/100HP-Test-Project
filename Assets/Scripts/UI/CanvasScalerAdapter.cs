using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(CanvasScaler))]
    public class CanvasScalerAdapter : MonoBehaviour
    {
        [SerializeField] private bool _isActive;
        
        private Vector2 _referenceResolution;

        private CanvasScaler _canvasScaler;

        private void Awake()
        {
            if (!_isActive) return;
            
            _canvasScaler = GetComponent<CanvasScaler>();
            _referenceResolution = _canvasScaler.referenceResolution;

            float currentRatio = (float) Screen.height / Screen.width;
            float goalRatio = _referenceResolution.y / _referenceResolution.x;

            _canvasScaler.matchWidthOrHeight = currentRatio <= goalRatio ? 1 : 0;
        }
    }
}