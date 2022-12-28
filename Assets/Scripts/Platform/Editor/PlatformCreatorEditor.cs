using UnityEngine;
using UnityEditor;

namespace Platform
{
    [CustomEditor(typeof(PlatformCreator))]
    [CanEditMultipleObjects]
    public class PlatformCreatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            PlatformCreator platform = (PlatformCreator)target;
            if (GUILayout.Button("Create Platform"))
                platform.CreatePlatform();
            serializedObject.Update();
        }
    }
}