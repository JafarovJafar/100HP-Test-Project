using System;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    [RequireComponent(typeof(Button))]
    public class UpgradeButton : MonoBehaviour
    {
        public event Action Clicked;

        private Button _button;

        public void Init()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Button_Clicked);
        }

        private void Button_Clicked() => Clicked?.Invoke();
    }
}