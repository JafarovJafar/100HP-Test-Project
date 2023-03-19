using UnityEngine;

public class Preloader : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("аналитика инициализирована");
        Debug.Log("реклама инициализирована");

        SceneManagerHelper.LoadLobbyScene();
    }
}