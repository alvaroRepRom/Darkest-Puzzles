using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueButton;

        private void Awake()
        {
            newGameButton.Select();
            IsContinueButtonDisable();
        }

        private void IsContinueButtonDisable()
        {
            if (GameManager.Instance.HasSavedData()) return;
            continueButton.interactable = false;
            TextMeshProUGUI text = continueButton.GetComponentInChildren<TextMeshProUGUI>();
            Color c = text.color;
            c.a = 0.5f;
            text.color = c;
        }
    }
}