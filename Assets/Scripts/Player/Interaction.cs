using UnityEngine;

namespace Player
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private LayerMask interactableMask;
        private const KeyCode interactKey = KeyCode.E;

        private void Update()
        {
            if (Input.GetKeyDown(interactKey))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f, interactableMask);
                if (hit) hit.collider.GetComponent<IInteractable>()?.Interact();
            }
        }
    }
}