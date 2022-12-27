using UnityEngine;

namespace Player
{
    public class Death : MonoBehaviour, IDamage
    {
        private Animator anim;
        private void Awake() => anim = GetComponent<Animator>();
        public void Damage() => anim.SetTrigger(AnimatorVar.HAS_DIED);
        public void Reset() => GameManager.Instance.ResetScene();
    }
}