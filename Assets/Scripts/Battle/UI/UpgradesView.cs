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

        private IHero _hero;

        public void Init(IHero hero, IBalance balance, IAudioManager audioManager)
        {
            _hero = hero;
            _hero.Upgraded += Hero_Upgraded;

            _rangeUpgradeButton.Init(balance, audioManager);
            _frequencyUpgradeButton.Init(balance, audioManager);
            _strengthUpgradeButton.Init(balance, audioManager);

            _rangeUpgradeButton.Clicked += RangeUpgrade_Clicked;
            _frequencyUpgradeButton.Clicked += FrequencyUpgrade_Clicked;
            _strengthUpgradeButton.Clicked += StrengthUpgrade_Clicked;

            Hero_Upgraded();
        }

        private void RangeUpgrade_Clicked() => UpgradeRangeClicked?.Invoke();
        private void FrequencyUpgrade_Clicked() => UpgradeFrequencyClicked?.Invoke();
        private void StrengthUpgrade_Clicked() => UpgradeStrengthClicked?.Invoke();

        private void Hero_Upgraded()
        {
            Stat stat;

            if (_hero.CurrentAttackRangeLevel < _hero.AttackRangeStats.Values.Count - 1)
            {
                stat = _hero.AttackRangeStats.Values[_hero.CurrentAttackRangeLevel + 1];
                _rangeUpgradeButton.SetCost(stat.Cost);
            }
            else _rangeUpgradeButton.SetFilled();

            if (_hero.CurrentAttackIntervalLevel < _hero.AttackIntervalStats.Values.Count - 1)
            {
                stat = _hero.AttackIntervalStats.Values[_hero.CurrentAttackIntervalLevel + 1];
                _frequencyUpgradeButton.SetCost(stat.Cost);
            }
            else _frequencyUpgradeButton.SetFilled();

            if (_hero.CurrentAttackStrengthLevel < _hero.AttackStrengthStats.Values.Count - 1)
            {
                stat = _hero.AttackStrengthStats.Values[_hero.CurrentAttackStrengthLevel + 1];
                _strengthUpgradeButton.SetCost(stat.Cost);
            }
            else _strengthUpgradeButton.SetFilled();
        }
    }
}