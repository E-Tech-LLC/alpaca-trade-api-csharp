﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PolygonSdk
{
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class AssumeUtcIsoDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(
            JsonWriter writer, 
            Object? value, 
            JsonSerializer serializer)
        {
            switch (value)
            {
                case DateTime dateTimeValue:
                    writer.WriteValue(dateTimeValue.ToString("O"));
                    break;

                case null:
                    writer.WriteNull();
                    break;
            }
        }
        public override Object? ReadJson(
            JsonReader reader,
            Type objectType,
            Object? existingValue,
            JsonSerializer serializer)
        {
            return DateTimeOffset.TryParse(reader.Value?.ToString(),
                CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, 
                out var dateTimeOffset)
                ? dateTimeOffset.UtcDateTime
                : (Object?) null;
        }
    }
}
