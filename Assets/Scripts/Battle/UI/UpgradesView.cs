using System;
using UnityEngine;

namespace Battle.UI
{
    public class UpgradesView : MonoBehaviour
    {
        public event Action UpgradeRangeClicked;
        public event Action UpgradeFrequencyClicked;
        public event Action UpgradeStrengthClicked;

        [SerializeField] private UpgradeButton _rangeUpgradeButton;
        [SerializeField] private UpgradeButton _frequencyUpgradeButton;
        [SerializeField] private UpgradeButton _strengthUpgradeButton;

        public void Init()
        {
            _rangeUpgradeButton.Clicked += RangeUpgrade_Clicked;
            _frequencyUpgradeButton.Clicked += FrequencyUpgrade_Clicked;
            _strengthUpgradeButton.Clicked += StrengthUpgrade_Clicked;
        }

        private void RangeUpgrade_Clicked() => UpgradeRangeClicked?.Invoke();
        private void FrequencyUpgrade_Clicked() => UpgradeFrequencyClicked?.Invoke();
        private void StrengthUpgrade_Clicked() => UpgradeStrengthClicked?.Invoke();
    }
}