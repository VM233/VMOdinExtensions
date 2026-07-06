using System;
using System.Diagnostics;

namespace VMFramework.OdinExtensions
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
                    AttributeTargets.Parameter | AttributeTargets.Class)]
    [Conditional("UNITY_EDITOR")]
    public class IsSingleFlagAttribute : SingleValidationAttribute
    {
        
    }
}