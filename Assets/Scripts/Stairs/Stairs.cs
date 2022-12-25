using UnityEngine;
using ARR.TransformEX;

namespace Stairs
{    
    public class Stairs : MonoBehaviour
    {
        [SerializeField] private GameObject stairsTile;
        [SerializeField] private GameObject endStairsTile;
        [SerializeField][Min(1)] private int numOfTiles;

        public void CreateStairs()
        {
            transform.DestroyChildren();
            for (int i = 0; i < numOfTiles; i++)
            {
                Vector3 pos = transform.position + Vector3.up * i;
                GameObject stepTile = Instantiate(TileToChoose(i), pos, Quaternion.identity);
                stepTile.transform.parent = transform;
            }
            ModifyCollider();
        }

        private void ModifyCollider()
        {
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = transform.GetChild(numOfTiles - 1).GetComponent<SpriteRenderer>();
            Debug.Log(spriteRenderer.sprite);
            col.size   = new Vector2(col.size.x, numOfTiles);
            col.offset = new Vector2(0, 0.5f * (numOfTiles - 1));
        }

        private GameObject TileToChoose(int iteration)
        {
            return iteration == numOfTiles - 1 ? endStairsTile : stairsTile;
        }
    }
}