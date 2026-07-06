#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VMFramework.OdinExtensions
{
    internal sealed class SceneDrawer : OdinValueDrawer<Scene>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var rect = SirenixEditorGUI.BeginVerticalPropertyLayout(label, out var labelRect);
            var value = this.ValueEntry.SmartValue;
            SirenixEditorFields.IntField("Handle", GetSceneHandleValue(value));
            EditorGUILayout.TextField("Name", value.name, EditorStyles.textField);
            SirenixEditorGUI.EndVerticalPropertyLayout();
        }

        private static int GetSceneHandleValue(Scene scene)
        {
#if UNITY_6000_5_OR_NEWER
            return scene.handle.GetRawData();
#else
            return scene.handle;
#endif
        }
    }
}
#endif
