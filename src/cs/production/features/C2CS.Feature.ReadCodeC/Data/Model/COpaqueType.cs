// Copyright (c) Bottlenose Labs Inc. (https://github.com/bottlenoselabs). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace C2CS.Feature.ReadCodeC.Data.Model;

public record COpaqueType : CNodeWithLocation
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("size_of")]
    public int SizeOf { get; set; }

    [ExcludeFromCodeCoverage]
    public override string ToString()
    {
        return $"OpaqueType '{Name}' @ {Location}";
    }
}
