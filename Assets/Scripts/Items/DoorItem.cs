using UnityEngine;

namespace Items
{
    public class DoorItem : MonoBehaviour, IOnButtonPushed
    {
        [SerializeField] private Sprite openDoor;
        [SerializeField] private Sprite closeDoor;

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
            isOpen = !isOpen;
            col.isTrigger = isOpen;
            spriteRenderer.sprite = isOpen ? openDoor : closeDoor;
        }
    }
}