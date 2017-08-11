// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Logic.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Fluent;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for HashingAlgorithm.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HashingAlgorithm
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "MD5")]
        MD5,
        [EnumMember(Value = "SHA1")]
        SHA1,
        [EnumMember(Value = "SHA2256")]
        SHA2256,
        [EnumMember(Value = "SHA2384")]
        SHA2384,
        [EnumMember(Value = "SHA2512")]
        SHA2512
    }
    internal static class HashingAlgorithmEnumExtension
    {
        internal static string ToSerializedValue(this HashingAlgorithm? value)
        {
            return value == null ? null : ((HashingAlgorithm)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this HashingAlgorithm value)
        {
            switch( value )
            {
                case HashingAlgorithm.NotSpecified:
                    return "NotSpecified";
                case HashingAlgorithm.None:
                    return "None";
                case HashingAlgorithm.MD5:
                    return "MD5";
                case HashingAlgorithm.SHA1:
                    return "SHA1";
                case HashingAlgorithm.SHA2256:
                    return "SHA2256";
                case HashingAlgorithm.SHA2384:
                    return "SHA2384";
                case HashingAlgorithm.SHA2512:
                    return "SHA2512";
            }
            return null;
        }

        internal static HashingAlgorithm? ParseHashingAlgorithm(this string value)
        {
            switch( value )
            {
                case "NotSpecified":
                    return HashingAlgorithm.NotSpecified;
                case "None":
                    return HashingAlgorithm.None;
                case "MD5":
                    return HashingAlgorithm.MD5;
                case "SHA1":
                    return HashingAlgorithm.SHA1;
                case "SHA2256":
                    return HashingAlgorithm.SHA2256;
                case "SHA2384":
                    return HashingAlgorithm.SHA2384;
                case "SHA2512":
                    return HashingAlgorithm.SHA2512;
            }
            return null;
        }
    }
}