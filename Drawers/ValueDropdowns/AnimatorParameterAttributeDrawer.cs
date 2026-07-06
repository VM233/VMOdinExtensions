#if UNITY_EDITOR && ODIN_INSPECTOR
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Core;
using VMFramework.Core.Linq;

namespace VMFramework.OdinExtensions
{
    public class AnimatorParameterAttributeDrawer : GeneralValueDropdownAttributeDrawer<AnimatorParameterAttribute>
    {
        protected override IEnumerable<ValueDropdownItem> GetValues()
        {
            foreach (var parent in Property.TraverseToRoot(false, property => property.Parent))
            {
                var animator = GetAnimator(parent.ParentValues);
                if (animator == null)
                {
                    continue;
                }

                if (Attribute.ParameterType.HasValue)
                {
                    return animator.parameters.Where(p => p.type == Attribute.ParameterType.Value)
                        .Select(p => new ValueDropdownItem(p.name, p.name));
                }

                return animator.parameters.Select(p => new ValueDropdownItem(p.name, p.name));
            }

            return Enumerable.Empty<ValueDropdownItem>();
        }

        protected virtual Animator GetAnimator(IList<object> parentValues)
        {
            if (parentValues.IsNullOrEmpty())
            {
                return null;
            }

            var parentValue = parentValues.First();
            if (parentValue == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(Attribute.AnimatorFieldName) == false)
            {
                return GetAnimatorFromMember(parentValue, Attribute.AnimatorFieldName);
            }

            if (parentValue is Component component)
            {
                return component.GetComponentInParent<Animator>(true);
            }

            return null;
        }

        protected virtual Animator GetAnimatorFromMember(object parentValue, string memberName)
        {
            var type = parentValue.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            while (type != null)
            {
                var fieldInfo = type.GetField(memberName, bindingFlags);
                if (fieldInfo != null)
                {
                    return fieldInfo.GetValue(parentValue) as Animator;
                }

                var propertyInfo = type.GetProperty(memberName, bindingFlags);
                if (propertyInfo is { CanRead: true } && propertyInfo.GetIndexParameters().Length == 0)
                {
                    return propertyInfo.GetValue(parentValue) as Animator;
                }

                type = type.BaseType;
            }

            return null;
        }
    }
}
#endif
