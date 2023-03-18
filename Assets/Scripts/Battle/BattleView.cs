using System;
using UnityEngine;
using Battle.UI;

namespace Battle
{
    public class BattleView : MonoBehaviour
    {
        public event Action UpgradeRangeClicked;
        public event Action UpgradeFrequencyClicked;
        public event Action UpgradeStrengthClicked;
        
        [SerializeField] private UpgradesView _upgradesView;

        public void Init()
        {
            _upgradesView.Init();
            
        }

        private void UpgradesView_RangeClicked() => UpgradeRangeClicked?.Invoke();
    }
}