using UnityEngine;

namespace Items
{
    public class DoorItem : MonoBehaviour, IChangeOnScene
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

        private void ChangeDoor()
        {
            isOpen = !isOpen;
            col.isTrigger = isOpen;
            spriteRenderer.sprite = isOpen ? openDoor : closeDoor;
        }

        public void Change(bool canBlock)
        {
            if (isBlocked && !canBlock) return;
            if (canBlock) isBlocked = !isBlocked;
            else ChangeDoor();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                GameManager.Instance.NextScene();
        }
    }
}