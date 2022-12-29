using UnityEngine;

public class AlienBlueShader : MonoBehaviour
{
    private Animator anim;
    private Material material;
    private const string IS_COLOR_ALPHA = "_IsColorAlpha";
    private const string IS_MOVING = "IsMoving";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update() => material.SetInt(IS_COLOR_ALPHA, IsColorAlpha());
    private int IsColorAlpha() { return anim.GetBool(IS_MOVING) ? 1 : 0; }
}
