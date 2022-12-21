using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Items
{
    public class LightItem : MonoBehaviour, IOnButtonPushed
    {
        [SerializeField] private Light2D spriteLight;
        [SerializeField] private Light2D light2D;

        public void Change()
        {
            spriteLight.enabled = !spriteLight.enabled;
            light2D.enabled = !light2D.enabled;
        }
    }
}