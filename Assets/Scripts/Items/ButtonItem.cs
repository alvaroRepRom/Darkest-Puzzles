using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Items
{
    public class ButtonItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> lightObjs;
        [SerializeField] private bool canBlock;

        private Light2D buttonLight;
        private bool isHighIntensity;
        private float hightIntensity = 0.75f;
        private float lowIntensity = 0.3f;

        private void Awake() => buttonLight = GetComponent<Light2D>();
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