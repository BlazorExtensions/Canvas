using Blazor.Extensions.Canvas.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.Canvas.Model
{
    public class ImageData
    {
        [JsonPropertyName("data")]
        [JsonConverter(typeof(ImageDataArrayConverter))]
        public byte[] Data { get; set; }

        [JsonPropertyName("width")]
        public ulong Width { get; set; }

        [JsonPropertyName("height")]
        public ulong Height { get; set; }
    }
}
