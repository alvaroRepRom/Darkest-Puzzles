using UnityEngine;
using UnityEngine.UI;

namespace ARR.UIEX
{
    public static partial class ExtendedMethods
    {
        /// <summary>
        /// This change the alpha of an Image
        /// <paramref name="alpha"/> Number between 0 (transparent) and 1 (opaque) <\paramref>
        /// <\summary>
        public static void Alpha(this Image img, float alpha)
        {
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }
    }
}