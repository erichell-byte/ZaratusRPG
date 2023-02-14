using System;
using JetBrains.Annotations;

namespace Services
{
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public class ServiceInjectAttribute : Attribute
    {
        
    }
}