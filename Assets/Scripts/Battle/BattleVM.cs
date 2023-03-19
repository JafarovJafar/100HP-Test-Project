namespace Battle
{
    public class LevelVM
    {
        public LevelVM(BattleModel model, BattleView view)
        {
            _model = model;
            _view = view;

            _view.RestartClicked += _model.Finish;
            
            _upgradesVM = new UpgradesVM(model.Hero, view.UpgradesView);
            _balanceVM = new BalanceVM(model.Balance, view.BalanceView);
        }

        private BattleModel _model;
        private BattleView _view;

        private UpgradesVM _upgradesVM;
        private BalanceVM _balanceVM;
    }
}