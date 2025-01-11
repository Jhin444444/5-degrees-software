using UnityEngine;
using Fusion;

public class server : NetworkBehaviour
{
    private NetworkRunner _networkRunner;

    async void Start()
    {
        // Создаём NetworkRunner
        _networkRunner = gameObject.AddComponent<NetworkRunner>();

        // Запускаем сервер
        await _networkRunner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Host, // Режим Host для сервера
            SessionName = "2DGameSession", // Имя сессии
            Scene = null, // Текущая сцена
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>() // Управление сценой
        });

        Debug.Log("Сервер Fusion запущен для 2D!");
    }
}