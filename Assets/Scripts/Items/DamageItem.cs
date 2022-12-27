using UnityEngine;

namespace Items
{
    public class DamageItem : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                collision.GetComponent<IDamage>()?.Damage();
        }
    }
}