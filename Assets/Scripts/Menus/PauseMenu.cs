using UnityEngine;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuCanvas;

        private bool isPaused;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseGame();
        }

        public void PauseGame()
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenuCanvas.SetActive(isPaused);
        }

        public void ResetLevel()
        {
            Time.timeScale = 1;
            GameManager.Instance.ResetScene();
        }

        public void ExitGame()
        {
            Time.timeScale = 1;
            GameManager.Instance.LoadMainMenu();
        }
    }
}