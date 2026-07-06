#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEngine;
using VMFramework.Core;

namespace VMFramework.OdinExtensions
{
    internal sealed class MinimumAttributeDrawer : SingleValidationAttributeDrawer<MinimumAttribute>
    {
        private ValueResolver<double> minValueGetter;

        private bool isProvider;
        private bool canClamp;

        protected override void Initialize() =>
            minValueGetter = ValueResolver.Get(Property, Attribute.MinExpression, Attribute.MinValue);

        protected override bool Validate(object value)
        {
            if (value is null)
            {
                return true;
            }

            if (value is IMinimumValueProvider provider)
            {
                isProvider = true;

                canClamp = provider.CanClampByMinimum;

                return canClamp;
            }

            if (value is IMinimumClampable<double>)
            {
                isProvider = true;
                canClamp = true;
                return true;
            }

            isProvider = false;
            return false;
        }

        protected override string GetDefaultMessage(GUIContent label, object value)
        {
            if (isProvider == false)
            {
                return $"{value.GetType().GetNiceName()} does not implement {typeof(IMinimumValueProvider)}";
            }

            if (canClamp == false)
            {
                return $"Cannot clamp {value.GetType().GetNiceName()} by minimum value.";
            }

            return string.Empty;
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            if (minValueGetter.HasError)
            {
                SirenixEditorGUI.ErrorMessageBox(minValueGetter.ErrorMessage);
                CallNextDrawer(label);
                return;
            }

            base.DrawPropertyLayout(label);
        }

        protected override void OnAfterValidate(GUIContent label, object value)
        {
            base.OnAfterValidate(label, value);

            if (IsValid)
            {
                double min = minValueGetter.GetValue();

                if (value is IMinimumValueProvider provider)
                {
                    provider.ClampByMinimum(min);
                }
                else if (value is IMinimumClampable<double> clampable)
                {
                    clampable.TryClampByMinimum(min);
                }
            }
        }
    }
}
#endif