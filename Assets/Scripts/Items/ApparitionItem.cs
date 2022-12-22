using UnityEngine;

namespace Items
{
    public class ApparitionItem : MonoBehaviour, IOnButtonPushed, IBlockChange
    {
        [SerializeField] private bool isBlocked;

        public void BlockChange()
        {
            isBlocked = !isBlocked;
        }

        public void Change()
        {
            if (isBlocked) return;
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}