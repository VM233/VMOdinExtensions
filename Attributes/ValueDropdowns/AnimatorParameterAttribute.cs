using System;
using System.Diagnostics;
using UnityEngine;

namespace VMFramework.OdinExtensions
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    [Conditional("UNITY_EDITOR")]
    public class AnimatorParameterAttribute : GeneralValueDropdownAttribute
    {
        public AnimatorControllerParameterType? ParameterType;

        public string AnimatorFieldName;

        public AnimatorParameterAttribute()
        {
            ParameterType = null;
            AnimatorFieldName = null;
        }

        public AnimatorParameterAttribute(string animatorFieldName)
        {
            ParameterType = null;
            AnimatorFieldName = animatorFieldName;
        }

        public AnimatorParameterAttribute(AnimatorControllerParameterType parameterType)
        {
            ParameterType = parameterType;
            AnimatorFieldName = null;
        }

        public AnimatorParameterAttribute(AnimatorControllerParameterType parameterType, string animatorFieldName)
        {
            ParameterType = parameterType;
            AnimatorFieldName = animatorFieldName;
        }
    }
}
