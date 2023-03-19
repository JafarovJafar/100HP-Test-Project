using TMPro;
using UnityEngine;

namespace Battle.UI
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        private IBalance _balance;

        public void Init(IBalance balance)
        {
            _balance = balance;
            _balance.Updated += UpdateView;
            
            UpdateView();
        }

        private void UpdateView()
        {
            _moneyText.text = $"{_balance.Money}";
        }
    }
}