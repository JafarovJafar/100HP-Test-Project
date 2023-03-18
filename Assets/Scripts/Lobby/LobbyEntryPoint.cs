using UnityEngine;

namespace Lobby
{
    public class LobbyEntryPoint : MonoBehaviour
    {
        [SerializeField] private LobbyModel _model;
        [SerializeField] private LobbyView _view;

        private LobbyVM _lobbyVm;

        private void Start()
        {
            Debug.Log("лобби пока что не сделан)))");
            SceneManagerHelper.LoadBattleScene();

            return;

            _model.Init();
            _view.Init();

            _lobbyVm = new LobbyVM(_model, _view);
        }
    }
}