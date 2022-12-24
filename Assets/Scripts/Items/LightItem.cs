using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Items
{
    public class LightItem : MonoBehaviour, IChangeOnScene
    {
        [SerializeField] private Light2D spriteLight;
        [SerializeField] private Light2D light2D;
        [SerializeField] private ColorSO colorSO;

        private void Awake()
        {
            spriteLight.color = colorSO.color;
            light2D.color = colorSO.color;
        }

        private void SwitchLights()
        {
            spriteLight.enabled = !spriteLight.enabled;
            light2D.enabled = !light2D.enabled;
        }

        public void Change(bool canBlock) => SwitchLights();
    }
}