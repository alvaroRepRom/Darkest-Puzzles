using UnityEngine;
using UnityEngine.UI;

namespace ARR
{
    public static partial class ExtendedMethods
    {
        /// <summary>
        /// This change the alpha of an Image
        /// <\summary>
        public static void Alpha(this Image img, float alpha)
        {
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }
        /// <summary>
        /// Change velocity in X axis.
        /// </summary>
        public static void VelX(this Rigidbody2D rb, float velX)
        {
            rb.velocity = new Vector2(velX, rb.velocity.y);
        }
        /// <summary>
        /// Change velocity in Y axis.
        /// </summary>
        public static void VelY(this Rigidbody2D rb, float velY)
        {
            rb.velocity = new Vector2(rb.velocity.x, velY);
        }
        /// <summary>
        /// Change position in 2D space.
        /// </summary>
        public static void Position2D(this Transform trans, Vector2 pos)
        {
            trans.position = new Vector3(pos.x, pos.y, trans.position.z);
        }

        public static void X(this Transform trans, float x)
        {
            trans.position = new Vector3(x, trans.position.y, trans.position.z);
        }
    }

}
