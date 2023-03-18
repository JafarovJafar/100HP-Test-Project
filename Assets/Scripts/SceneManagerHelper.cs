using UnityEngine.SceneManagement;

public static class SceneManagerHelper
{
    public static void LoadLobbyScene() => SceneManager.LoadScene(1, LoadSceneMode.Single);
    public static void LoadBattleScene() => SceneManager.LoadScene(2, LoadSceneMode.Single);
}