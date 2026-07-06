using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using VMFramework.Core;
using VMFramework.Core.Editor;

namespace VMFramework.OdinExtensions
{
    internal sealed class RectangleFloatDrawer : OdinValueDrawer<RectangleFloat>, IDefinesGenericMenuItems
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            var rect = GUIHelper.GetCurrentLayoutRect();
            var value = DragAndDropUtilities.DragAndDropZone(rect, null, typeof(Object), allowMove: true,
                allowSwap: true, allowSceneObjects: true);
            if (EditorGUI.EndChangeCheck())
            {
                if (value.TryGetComponent(out BoxCollider2D boxCollider))
                {
                    Property.RecordForUndo("Rectangle Float Value Changed");
                    var colliderRect = boxCollider.GetRectangle();
                    ValueEntry.SmartValue = colliderRect;
                    ValueEntry.ApplyChanges();
                }
            }

            CallNextDrawer(label);
        }

        void IDefinesGenericMenuItems.PopulateGenericMenu(InspectorProperty property, GenericMenu genericMenu)
        {
            genericMenu.AddSeparator();

            genericMenu.AddItem("Reset", () =>
            {
                ValueEntry.SmartValue = RectangleFloat.Zero;
                ValueEntry.ApplyChanges();
            });
        }
    }
}