﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PolygonSdk
{
    /// <summary>
    /// Position side in Alpaca REST API.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage(
        "Naming", "CA1720:Identifier contains type name",
        Justification = "Both names are trading terms not CLR type names.")]
    public enum PositionSide
    {
        /// <summary>
        /// Long position.
        /// </summary>
        [EnumMember(Value = "long")]
        Long,

        /// <summary>
        /// Short position.
        /// </summary>
        [EnumMember(Value = "short")]
        Short
    }
}
