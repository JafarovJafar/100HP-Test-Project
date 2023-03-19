using UnityEngine;
using Battle.UI;

namespace Battle
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private BalanceView _balanceView;
        [SerializeField] private UpgradesView _upgradesView;

        public BalanceView BalanceView => _balanceView;
        public UpgradesView UpgradesView => _upgradesView;

        private IAudioManager _audioManager;

        public void Init(IBattleModel battleModel, IAudioManager audioManager)
        {
            _audioManager = audioManager;

            _balanceView.Init(battleModel.Balance);
            _upgradesView.Init(battleModel.Hero, battleModel.Balance, audioManager);
        }
    }
}