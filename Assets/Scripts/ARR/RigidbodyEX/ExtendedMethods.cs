using UnityEngine;

namespace ARR.RigidbodyEX
{
    public static partial class ExtendedMethods
    {
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
    }
}
