// Copyright (c) Bottlenose Labs Inc. (https://github.com/bottlenoselabs). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Collections.Immutable;

namespace C2CS.Features.WriteCodeCSharp.Data;

public sealed class CSharpStructField : CSharpNode
{
    public readonly string BackingFieldName;
    public readonly bool IsWrapped;
    public readonly int OffsetOf;
    public readonly CSharpTypeInfo TypeInfo;

    public CSharpStructField(
        string name,
        string className,
        string cName,
        int? sizeOf,
        CSharpTypeInfo typeInfo,
        int offsetOf,
        bool isWrapped,
        ImmutableArray<Attribute> attributes)
        : base(name, className, cName, sizeOf, attributes)
    {
        TypeInfo = typeInfo;
        OffsetOf = offsetOf;
        IsWrapped = isWrapped;
        BackingFieldName = name.StartsWith("@", StringComparison.InvariantCulture) ? $"_{name[1..]}" : $"_{name}";
    }

    public override bool Equals(CSharpNode? other)
    {
        if (!base.Equals(other) || other is not CSharpStructField other2)
        {
            return false;
        }

        return BackingFieldName == other2.BackingFieldName &&
               IsWrapped == other2.IsWrapped &&
               OffsetOf == other2.OffsetOf &&
               TypeInfo == other2.TypeInfo;
    }

    public override int GetHashCode()
    {
        var baseHashCOde = base.GetHashCode();
        var hashCode = HashCode.Combine(baseHashCOde, BackingFieldName, IsWrapped, OffsetOf, TypeInfo);
        return hashCode;
    }
}
