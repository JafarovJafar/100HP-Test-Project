namespace Battle
{
    public class LevelVM
    {
        public LevelVM(BattleModel model, BattleView view)
        {
            _model = model;
            _view = view;
        }

        private BattleModel _model;
        private BattleView _view;
    }
}