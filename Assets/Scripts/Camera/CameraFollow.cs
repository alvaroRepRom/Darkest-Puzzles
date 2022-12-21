using UnityEngine;

namespace MyCamera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] [Range(0, 1)] private float dumping;
        [SerializeField] private float xOffset;
        [SerializeField] private float yOffset;

        private Vector3 offset;
        private float minDistanceToFollow = 0.07f;

        private void Awake()
        {
            offset = new Vector3(xOffset, yOffset, transform.position.z - target.position.z);
        }

        private void LateUpdate()
        {
            Vector3 posToMove = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, posToMove, dumping * Time.deltaTime);

            if (Vector3.Distance(transform.position, posToMove) < minDistanceToFollow)
            {
                transform.position = posToMove;
            }
        }
    }
}