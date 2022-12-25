using UnityEngine;
using UnityEngine.UI;

namespace ARR.UIEX
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
    }
}