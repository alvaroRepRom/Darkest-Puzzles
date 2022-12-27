using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;

    private bool isPaused;

    public void PauseGame()
    {
        Time.timeScale = isPaused ? 1 : 0;
    }

    public void ResetLevel()
    {
        GameManager.Instance.ResetScene();
    }

    public void ExitGame()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
