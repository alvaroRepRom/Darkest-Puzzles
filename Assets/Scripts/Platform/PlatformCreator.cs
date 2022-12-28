using UnityEngine;
using ARR.TransformEX;

namespace Platform
{    
    public class PlatformCreator : MonoBehaviour
    {
        [SerializeField] private GameObject groundTile;
        [SerializeField] [Min(1)] private int numOfTiles;

        public void CreatePlatform()
        {
            transform.DestroyChildrenInmediate();
            for (int i = 0; i < numOfTiles; i++)
            {
                Vector3 pos = transform.position + Vector3.right * i;
                GameObject stepTile = Instantiate(groundTile, pos, Quaternion.identity);
                stepTile.transform.parent = transform;
            }
            ModifyCollider();
        }

        private void ModifyCollider()
        {
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            col.size = new Vector2(numOfTiles, col.size.y);
            col.offset = new Vector2(0.5f * (numOfTiles - 1), col.offset.y);
        }
    }
}