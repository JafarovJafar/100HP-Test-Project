namespace Lobby
{
    public class LobbyVM
    {
        private LobbyModel _model;
        private LobbyView _view;
        
        public LobbyVM(LobbyModel model, LobbyView view)
        {
            _model = model;
            _view = view;
        }
    }
}