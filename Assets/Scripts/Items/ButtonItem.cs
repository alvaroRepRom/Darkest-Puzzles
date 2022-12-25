using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Items
{
    public class ButtonItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private ColorSO colorSO;
        [SerializeField] private List<GameObject> lightObjs;
        [SerializeField] private bool canBlock;

        private Light2D buttonLight;
        private bool isHighIntensity;
        private const float hightIntensity = 0.75f;
        private const float lowIntensity = 0.3f;

        private void Awake()
        {
            buttonLight = GetComponent<Light2D>();
            buttonLight.color = colorSO.color;
        }
        public void Interact()
        {
            ChangeIntensity();
            SceneChanges();
        }

        private void SceneChanges()
        {
            foreach (GameObject target in lightObjs)
                target.GetComponent<IChangeOnScene>()?.Change(canBlock);
        }

        private void ChangeIntensity()
        {
            buttonLight.intensity = isHighIntensity ? lowIntensity : hightIntensity;
            isHighIntensity = !isHighIntensity;
        }
    }
}