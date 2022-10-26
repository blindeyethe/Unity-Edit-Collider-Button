using UnityEditor;
using TheBlindEye.EditorExtensions;

namespace TheBlindEye
{
    [CustomEditor(typeof(MyScript))]
    public class MyScriptEditor : Editor
    {
        private SerializedProperty _editColliderProperty;
        
        private void OnEnable()
        {
            _editColliderProperty = serializedObject.FindProperty("editCollider");
        }
        
        public override void OnInspectorGUI()
        {
            Helpers.DrawEditButton(_editColliderProperty);
            
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }
}
