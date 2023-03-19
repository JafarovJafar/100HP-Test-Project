using UnityEngine;

namespace Battle
{
    public class BattleEntryPoint : MonoBehaviour
    {
        [SerializeField] private BattleModel _model;
        [SerializeField] private BattleView _view;

        private LevelVM _levelVM;

        private Balance _balance = new Balance(10);

        private void Start()
        {
            _model.Init(_balance);
            _view.Init(_model);

            _levelVM = new LevelVM(_model, _view);
        }
    }
}