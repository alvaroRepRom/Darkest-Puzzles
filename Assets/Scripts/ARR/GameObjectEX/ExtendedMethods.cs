using UnityEngine;

namespace ARR.GameObjectEX
{
    public static partial class ExtendedMethods
    {
        /// <summary>
        /// Destroy all children.
        /// </summary>
        public static void DestroyChildren(this GameObject gameObj)
        {
            int count = gameObj.transform.childCount;
            for (int i = 0; i < count; i++)
                GameObject.DestroyImmediate(gameObj.transform.GetChild(0).gameObject);
        }
    }
}