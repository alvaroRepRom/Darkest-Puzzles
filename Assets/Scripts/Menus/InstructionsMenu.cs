using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ARR.UIEX;

public class InstructionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private float fadeTime;
    private Coroutine cor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        panel.SetActive(true);
        //StopCoroutine(cor);
        //cor = StartCoroutine(FadeEffect());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        panel.SetActive(false);
        //StopCoroutine(cor);
        //cor = StartCoroutine(FadeEffect());
    }

    private IEnumerator FadeEffect()
    {
        Image img = panel.GetComponent<Image>();
        TextMeshProUGUI text = panel.GetComponentInChildren<TextMeshProUGUI>();
        Color c = text.color;
        float textAlpha = c.a;
        float timer = 0f;
        while (timer <= fadeTime)
        {
            timer += Time.deltaTime;

            img.Alpha(0);
            yield return null;
        }
    }
}
