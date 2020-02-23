using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.ValueObjects
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
