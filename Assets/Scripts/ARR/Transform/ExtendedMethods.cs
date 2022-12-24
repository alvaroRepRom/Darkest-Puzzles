using UnityEngine;

namespace ARR.transform
{
    public static partial class ExtendedMethods
    {
        /// <summary>
        /// Change position in 2D space.
        /// </summary>
        public static void Position2D(this Transform trans, Vector2 pos)
        {
            trans.position = new Vector3(pos.x, pos.y, trans.position.z);
        }
        /// <summary>
        /// Change X axis position.
        /// </summary>
        public static void X(this Transform trans, float x)
        {
            trans.position = new Vector3(x, trans.position.y, trans.position.z);
        }
    }
}
