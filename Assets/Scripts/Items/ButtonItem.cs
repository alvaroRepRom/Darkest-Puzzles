using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Items
{
    public class ButtonItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> targets;
        [SerializeField] private bool isHighIntensity;
        [SerializeField] private bool canBlock;

        private Light2D buttonLight;
        private float hightIntensity = 0.75f;
        private float lowIntensity = 0.3f;

        private void Awake() => buttonLight = GetComponent<Light2D>();
        public void Interact()
        {
            ChangeIntensity();
            foreach (GameObject target in targets)
            {
                //if (canBlock) target.GetComponent<IBlockChange>()?.BlockChange();
                target.GetComponent<IOnButtonPushed>()?.Change();
            }
        }

        private void ChangeIntensity()
        {
            buttonLight.intensity = isHighIntensity ? lowIntensity : hightIntensity;
            isHighIntensity = !isHighIntensity;
        }
    }
}