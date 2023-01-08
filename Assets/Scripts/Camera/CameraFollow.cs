using UnityEngine;
using ARR.TransformEX;

namespace MyCamera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] [Range(0, 1)] private float dumping;
        [Header("Axis Boundaries")]
        [SerializeField] private Vector2 xLimits;
        [SerializeField] private Vector2 yLimits;

        private Vector2 velocity = Vector3.zero;

        private void LateUpdate()
        {
            Vector2 targetPosition = new Vector3(Mathf.Clamp(target.position.x, xLimits.x, xLimits.y),
                                                Mathf.Clamp(target.position.y, yLimits.x, yLimits.y));
            transform.Position2D(Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, dumping));
        }
    }
}