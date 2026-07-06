using System;
using System.Diagnostics;

namespace VMFramework.OdinExtensions
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    [Conditional("UNITY_EDITOR")]
    public class VisualEffectPropertyNameAttribute : GeneralValueDropdownAttribute
    {
        public Type Type { get; set; }

        public VisualEffectPropertyNameAttribute(Type type = null)
        {
            Type = type;
        }
    }
}