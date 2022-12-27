using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NextScene()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(nextScene);
    }

    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
