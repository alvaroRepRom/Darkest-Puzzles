using UnityEngine;
using UnityEditor;

namespace Stairs
{
    [CustomEditor(typeof(Stairs))]
    [CanEditMultipleObjects]
    public class StairsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Stairs stairs = (Stairs)target;
            if (GUILayout.Button("Create Stairs"))
                stairs.CreateStairs();
            serializedObject.Update();
        }
    }
}