using UnityEditor;
using UnityEngine;

namespace TheBlindEye.EditorExtensions
{
    internal static class Helpers
    {
        private const string EDIT_COLLIDER_ICON = "d_EditCollider";
        private const float SPACE_AMPLIFIER_FOR_13_CHAR = 1.5f;
        private const float CHAR_AMPLIFIER = 0.1153846153846154f;
        
        private static readonly Color _notPressedColor = new Color32(150, 150, 150, 255);
        private static readonly Color _pressedColor = new Color32(255, 255, 255, 255);
        
        internal static void DrawEditButton(SerializedProperty property)
        {
            var editColliderIcon = EditorGUIUtility.IconContent(EDIT_COLLIDER_ICON);
            var oldColor = GUI.backgroundColor;

            bool isPressed = property.boolValue;
            using (new GUILayout.HorizontalScope())
            {
                string displayName = property.displayName;
                GUILayout.Label(displayName);

                GUILayout.Space(EditorGUIUtility.labelWidth - EditorGUIUtility.fieldWidth *
                    (SPACE_AMPLIFIER_FOR_13_CHAR - (displayName.Length / 13f - 1) * CHAR_AMPLIFIER));
                
                GUI.backgroundColor = isPressed ? _pressedColor : _notPressedColor;
                
                var wasPressed = GUILayout.Button(editColliderIcon, GUILayout.Height(22), GUILayout.Width(34));
                property.boolValue = wasPressed switch
                {
                    true when !isPressed => true,
                    true when true => false,
                    _ => property.boolValue
                };
                
                GUI.backgroundColor = oldColor;
                GUILayout.FlexibleSpace();
            }
            
            GUILayout.Space(2f);
        }
    }
}