using UnityEngine;

namespace Items
{
    public class ApparitionItem : MonoBehaviour, IOnButtonPushed
    {
        public void Change()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}