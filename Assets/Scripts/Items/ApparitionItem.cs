using UnityEngine;

namespace Items
{
    public class ApparitionItem : MonoBehaviour, IChangeOnScene
    {
        [SerializeField] private bool isBlocked;

        public void Change(bool canBlock)
        {
            if (isBlocked && !canBlock) return;
            if (canBlock) isBlocked = !isBlocked;
            else ObjectActivation();
        }

        private void ObjectActivation() => gameObject.SetActive(!gameObject.activeSelf);
    }
}