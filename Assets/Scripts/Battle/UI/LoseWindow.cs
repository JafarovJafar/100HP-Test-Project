using System;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class LoseWindow : MonoBehaviour
    {
        public event Action RestartClicked;

        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _restartButton;

        public void Init()
        {
            _restartButton.onClick.AddListener(() => RestartClicked?.Invoke());
        }

        public void Show()
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}