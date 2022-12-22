using UnityEditor;

namespace Items
{
    [CustomEditor(typeof(ButtonItem))]
    [CanEditMultipleObjects]
    public class ButtonItemEditor : Editor
    {/*
        SerializedProperty canBlock;
        SerializedProperty isBlocked;
        
        void OnEnable()
        {
            canBlock = serializedObject.FindProperty("canBlock");
            isBlocked = serializedObject.FindProperty("isBlocked");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            if (canBlock.boolValue)
                EditorGUILayout.PropertyField(isBlocked);
            serializedObject.ApplyModifiedProperties();
        }*/
    }
}