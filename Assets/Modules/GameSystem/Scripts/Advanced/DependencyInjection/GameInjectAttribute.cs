using System;
using JetBrains.Annotations;

namespace GameSystem
{
        [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
        public sealed class GameInjectAttribute : Attribute
        {
                
        }
}