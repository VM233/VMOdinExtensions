using System;
using UnityEngine;
using VMFramework.Core;

namespace VMFramework.OdinExtensions
{
    public class IsSingleFlagAttributeDrawer : SingleValidationAttributeDrawer<IsSingleFlagAttribute>
    {
        protected override bool Validate(object value)
        {
            if (value is not Enum enumValue)
            {
                return true;
            }

            var flagValue = Convert.ToInt32(enumValue);
            var flagCount = flagValue.GetFlagsCount();

            return flagCount == 1;
        }

        protected override string GetDefaultMessage(GUIContent label, object value)
        {
            var propertyName = label == null ? Property.Name : label.text;
            return $"{propertyName} must have only one flag set.";
        }
    }
}