using System;
using System.Diagnostics;

namespace VMFramework.OdinExtensions
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter,
        AllowMultiple = true)]
    [Conditional("UNITY_EDITOR")]
    public sealed class ComponentRequiredAttribute : SingleValidationAttribute
    {
        public Type ComponentType { get; set; }
        public string ComponentTypeGetter { get; set; }

        public ComponentRequiredAttribute(string componentTypeGetter)
        {
            ComponentTypeGetter = componentTypeGetter;
        }

        public ComponentRequiredAttribute(Type componentType)
        {
            ComponentType = componentType;
        }

        public ComponentRequiredAttribute(Type componentType, string errorMessage) : base(errorMessage)
        {
            ComponentType = componentType;
        }
    }
}