using UnityEngine;

namespace Item
{
    public class BlockChangeItem : MonoBehaviour, IOnButtonPushed
    {
        [SerializeField] private bool isBlocked;

        public void Change()
        {
            isBlocked = !isBlocked;
        }
    }
}