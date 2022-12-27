using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-400)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string SAVE_KEY = "level";

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NextScene()
    {
        int nextScene = ActiveScene() + 1;
        if (SceneManager.sceneCountInBuildSettings == nextScene)
        {
            PlayerPrefs.DeleteKey(SAVE_KEY);
            LoadMainMenu();
        }
        else
        {
            PlayerPrefs.SetInt(SAVE_KEY, nextScene);
            SceneManager.LoadScene(nextScene);
        }
    }
    public void ResetScene() => SceneManager.LoadScene(ActiveScene());
    public void LoadMainMenu() { SceneManager.LoadScene(0); }
    private int ActiveScene() { return SceneManager.GetActiveScene().buildIndex; }
    public bool HasSavedData() { return PlayerPrefs.HasKey(SAVE_KEY); }
    public void ContinueGame()
    {
        int level = PlayerPrefs.GetInt(SAVE_KEY);
        SceneManager.LoadScene(level);
    }
}
