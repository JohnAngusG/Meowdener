using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Messenger.AddListener(GameEvent.GAME_OVER, OnGameOver);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_OVER, OnGameOver);
    }
    private void OnGameOver() {
        SceneManager.LoadScene(2);
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);

    }

    public void OnQuitButton()
    {
        Application.Quit();

    }
}
