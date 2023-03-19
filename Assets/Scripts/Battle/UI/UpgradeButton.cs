using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    [RequireComponent(typeof(Button))]
    public class UpgradeButton : MonoBehaviour
    {
        public event Action Clicked;

        [SerializeField] private TextMeshProUGUI _costText;

        private Button _button;

        private IBalance _balance;
        private IAudioManager _audioManager;

        private float _cost;

        private bool _isFilled;

        public void Init(IBalance balance, IAudioManager audioManager)
        {
            _balance = balance;
            _balance.Updated += Balance_Updated;
            _audioManager = audioManager;

            _button = GetComponent<Button>();
            _button.onClick.AddListener(Button_Clicked);
        }

        public void SetCost(float cost)
        {
            _cost = cost;
            _costText.text = $"{_cost}";

            UpdateOutOfCost();
        }

        public void SetFilled()
        {
            _isFilled = true;
            _button.interactable = false;
            //_costText.gameObject.SetActive(false);
            _costText.text = "MAX";
        }

        private void Balance_Updated() => UpdateOutOfCost();

        private void UpdateOutOfCost()
        {
            if (_isFilled)
            {
                _button.interactable = false;
                return;
            }

            _button.interactable = _balance.Money >= _cost;
        }

        private void Button_Clicked()
        {
            _audioManager.PlayButtonClick();
            Clicked?.Invoke();
        }
    }
}