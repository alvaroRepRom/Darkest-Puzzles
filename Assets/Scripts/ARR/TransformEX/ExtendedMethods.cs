using UnityEngine;

namespace ARR.TransformEX
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
        /// <summary>
        /// Destroy all children inmediately. Use it on Edior or with care on Game.
        /// </summary>
        public static void DestroyChildrenInmediate(this Transform trans)
        {
            int count = trans.childCount;
            for (int i = 0; i < count; i++)
                Transform.DestroyImmediate(trans.GetChild(0).gameObject);
        }
        /// <summary>
        /// Destroy all children.
        /// </summary>
        public static void DestroyChildren(this Transform trans)
        {
            int count = trans.childCount;
            for (int i = 0; i < count; i++)
                Transform.Destroy(trans.GetChild(0).gameObject);
        }
    }
}
