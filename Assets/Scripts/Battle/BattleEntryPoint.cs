using UnityEngine;

namespace Battle
{
    public class BattleEntryPoint : MonoBehaviour
    {
        [SerializeField] private BattleModel _model;
        [SerializeField] private BattleView _view;
        [SerializeField] private AudioManager _audioManager;

        private LevelVM _levelVM;

        private Balance _balance = new Balance(10);

        private void Start()
        {
            _model.Init(_balance, _audioManager);
            _view.Init(_model, _audioManager);

            _levelVM = new LevelVM(_model, _view);
        }
    }
}