using UnityEngine;

namespace Battle
{
    public class BattleEntryPoint : MonoBehaviour
    {
        [SerializeField] private BattleModel _model;
        [SerializeField] private BattleView _view;

        private LevelVM _levelVM;

        private void Start()
        {
            _model.Init();
            _view.Init();

            _levelVM = new LevelVM(_model, _view);
        }
    }
}