// Copyright (c) Bottlenose Labs Inc. (https://github.com/bottlenoselabs). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the Git repository root directory for full license information.

using System;
using System.Runtime.InteropServices;
using C2CS;
using JetBrains.Annotations;

namespace C2CS;

/// <summary>
///     A pointer value type; represents the 16-bit C type `char16_t*`.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[PublicAPI]
public readonly unsafe struct CString8U : IEquatable<CString8U>
{
    internal readonly nint _pointer;

    /// <summary>
    ///     Gets a <see cref="bool" /> value indicating whether this <see cref="CString8U" /> is a null pointer.
    /// </summary>
    public bool IsNull => _pointer == 0;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CString8U" /> struct.
    /// </summary>
    /// <param name="value">The pointer value.</param>
    public CString8U(byte* value)
    {
        _pointer = (nint)value;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CString8U" /> struct.
    /// </summary>
    /// <param name="value">The pointer value.</param>
    public CString8U(nint value)
    {
        _pointer = value;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CString8U" /> struct.
    /// </summary>
    /// <param name="s">The string value.</param>
    public CString8U(string s)
    {
        _pointer = Runtime.CString8U(s);
    }

    /// <summary>
    ///     Performs an explicit conversion from a <see cref="IntPtr" /> to a <see cref="CString8U" />.
    /// </summary>
    /// <param name="value">The pointer value.</param>
    /// <returns>
    ///     The resulting <see cref="CString8U" />.
    /// </returns>
    public static explicit operator CString8U(nint value)
    {
        return FromIntPtr(value);
    }

    /// <summary>
    ///     Performs an explicit conversion from a <see cref="IntPtr" /> to a <see cref="CString8U" />.
    /// </summary>
    /// <param name="value">The pointer value.</param>
    /// <returns>
    ///     The resulting <see cref="CString8U" />.
    /// </returns>
    public static CString8U FromIntPtr(nint value)
    {
        return new(value);
    }

    /// <summary>
    ///     Performs an implicit conversion from a byte pointer to a <see cref="CString8U" />.
    /// </summary>
    /// <param name="value">The pointer value.</param>
    /// <returns>
    ///     The resulting <see cref="CString8U" />.
    /// </returns>
    public static implicit operator CString8U(byte* value)
    {
        return From(value);
    }

    /// <summary>
    ///     Performs an implicit conversion from a byte pointer to a <see cref="CString8U" />.
    /// </summary>
    /// <param name="value">The pointer value.</param>
    /// <returns>
    ///     The resulting <see cref="CString8U" />.
    /// </returns>
    public static CString8U From(byte* value)
    {
        return new((nint)value);
    }

    /// <summary>
    ///     Performs an implicit conversion from a <see cref="CString8U" /> to a <see cref="IntPtr" />.
    /// </summary>
    /// <param name="value">The pointer.</param>
    /// <returns>
    ///     The resulting <see cref="IntPtr" />.
    /// </returns>
    public static implicit operator nint(CString8U value)
    {
        return value._pointer;
    }

    /// <summary>
    ///     Performs an implicit conversion from a <see cref="CString8U" /> to a <see cref="IntPtr" />.
    /// </summary>
    /// <param name="value">The pointer.</param>
    /// <returns>
    ///     The resulting <see cref="IntPtr" />.
    /// </returns>
    public static nint ToIntPtr(CString8U value)
    {
        return value._pointer;
    }

    /// <summary>
    ///     Performs an implicit conversion from a <see cref="CString8U" /> to a <see cref="string" />.
    /// </summary>
    /// <param name="value">The <see cref="CString8U" />.</param>
    /// <returns>
    ///     The resulting <see cref="string" />.
    /// </returns>
    public static implicit operator string(CString8U value)
    {
        return ToString(value);
    }

    /// <summary>
    ///     Performs an implicit conversion from a <see cref="CString8U" /> to a <see cref="string" />.
    /// </summary>
    /// <param name="value">The <see cref="CString8U" />.</param>
    /// <returns>
    ///     The resulting <see cref="string" />.
    /// </returns>
    public static string ToString(CString8U value)
    {
        return Runtime.String8U(value);
    }

    /// <summary>
    ///     Performs an implicit conversion from a <see cref="string" /> to a <see cref="CString8U" />.
    /// </summary>
    /// <param name="s">The <see cref="string" />.</param>
    /// <returns>
    ///     The resulting <see cref="CString8U" />.
    /// </returns>
    public static implicit operator CString8U(string s)
    {
        return FromString(s);
    }

    /// <summary>
    ///     Performs an implicit conversion from a <see cref="string" /> to a <see cref="CString8U" />.
    /// </summary>
    /// <param name="s">The <see cref="string" />.</param>
    /// <returns>
    ///     The resulting <see cref="CString8U" />.
    /// </returns>
    public static CString8U FromString(string s)
    {
        return Runtime.CString8U(s);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Runtime.String8U(this);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is CBool b && Equals(b);
    }

    /// <inheritdoc />
    public bool Equals(CString8U other)
    {
        return _pointer == other._pointer;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return _pointer.GetHashCode();
    }

    /// <summary>
    ///     Returns a value that indicates whether two specified <see cref="CString8U" /> structures are equal.
    /// </summary>
    /// <param name="left">The first <see cref="CString8U" /> to compare.</param>
    /// <param name="right">The second <see cref="CString8U" /> to compare.</param>
    /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(CString8U left, CString8U right)
    {
        return left._pointer == right._pointer;
    }

    /// <summary>
    ///     Returns a value that indicates whether two specified <see cref="CBool" /> structures are not equal.
    /// </summary>
    /// <param name="left">The first <see cref="CString8U" /> to compare.</param>
    /// <param name="right">The second <see cref="CString8U" /> to compare.</param>
    /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(CString8U left, CString8U right)
    {
        return !(left == right);
    }

    /// <summary>
    ///     Returns a value that indicates whether two specified <see cref="CString8U" /> structures are equal.
    /// </summary>
    /// <param name="left">The first <see cref="CString8U" /> to compare.</param>
    /// <param name="right">The second <see cref="CString8U" /> to compare.</param>
    /// <returns><c>true</c> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <c>false</c>.</returns>
    public static bool Equals(CString8U left, CString8U right)
    {
        return left._pointer == right._pointer;
    }
}
