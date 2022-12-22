using UnityEngine;

namespace Items
{
    public class DoorItem : MonoBehaviour, IOnButtonPushed, IBlockChange
    {
        [SerializeField] private Sprite openDoor;
        [SerializeField] private Sprite closeDoor;
        [SerializeField] private bool isBlocked;

        private SpriteRenderer spriteRenderer;
        private Collider2D col;
        private bool isOpen;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            col = GetComponent<Collider2D>();
        }

        public void Change()
        {
            if (isBlocked) return;
            ChangeDoor();
        }

        private void ChangeDoor()
        {
            isOpen = !isOpen;
            col.isTrigger = isOpen;
            spriteRenderer.sprite = isOpen ? openDoor : closeDoor;
        }

        public void BlockChange()
        {
            isBlocked = !isBlocked;
        }
    }
}