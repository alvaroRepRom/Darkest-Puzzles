using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemy
{
    public class AlertDisplay : MonoBehaviour
    {
        [SerializeField] private Color alertColor;
        [SerializeField] private float transitionTime;

        private Coroutine cor;
        private Light2D sceneLight;
        private Color normalColor;
        private bool isOnAlert;

        public OnAlertSO onAlertSO;

        private void OnEnable() => onAlertSO.onAlert += AlertState;
        private void OnDisable() => onAlertSO.onAlert -= AlertState;

        private void Awake()
        {
            sceneLight = GetComponent<Light2D>();
            normalColor = sceneLight.color;
        }

        public void AlertState(bool isAlert)
        {
            if (isAlert == isOnAlert) return;
            isOnAlert = isAlert;
            if (cor != null) StopCoroutine(cor);
            cor = StartCoroutine(ChangeLightColor());
        }

        private IEnumerator ChangeLightColor()
        {
            if (isOnAlert)
            {
                while (true)
                {
                    float t = 0f;
                    while (t < transitionTime)
                    {
                        t += Time.deltaTime;
                        sceneLight.color = Color.Lerp(alertColor, normalColor, t);
                        yield return null;
                    }
                    yield return null;
                }
            }
            else
            {
                float t = 0f;
                while (t < transitionTime)
                {
                    t += Time.deltaTime;
                    sceneLight.color = Color.Lerp(alertColor, normalColor, t);
                    yield return null;
                }
                sceneLight.color = normalColor;
            }
        }
    }
}