using UnityEngine;

namespace Player
{
    public class Death : MonoBehaviour, IDamage
    {
        private Animator anim;
        private void Awake() => anim = GetComponent<Animator>();
        public void Damage() => anim.SetTrigger("HasDied");
        public void ResetScene() => GameManager.Instance.ResetScene();
    }
}