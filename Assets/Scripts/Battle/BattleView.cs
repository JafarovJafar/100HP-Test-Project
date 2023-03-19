using System;
using UnityEngine;
using Battle.UI;

namespace Battle
{
    public class BattleView : MonoBehaviour
    {
        public event Action RestartClicked;
        
        [SerializeField] private BalanceView _balanceView;
        [SerializeField] private UpgradesView _upgradesView;
        [SerializeField] private LoseWindow _loseWindow;

        public BalanceView BalanceView => _balanceView;
        public UpgradesView UpgradesView => _upgradesView;

        public void Init(IBattleModel battleModel, IAudioManager audioManager)
        {
            _balanceView.Init(battleModel.Balance);
            _upgradesView.Init(battleModel.Hero, battleModel.Balance, audioManager);
            
            _loseWindow.Init();
            _loseWindow.RestartClicked += LoseWindow_RestartClicked;

            battleModel.HeroDied += _loseWindow.Show;
        }

        private void LoseWindow_RestartClicked() => RestartClicked?.Invoke();
    }
}