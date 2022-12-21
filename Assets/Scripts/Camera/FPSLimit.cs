using UnityEngine;

namespace MyCamera
{
    public class FPSLimit : MonoBehaviour
    {
        [SerializeField] private int frameRate = 60;

        private void Awake()
        {
            Application.targetFrameRate = frameRate;
        }
    }
}