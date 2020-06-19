using Blazor.Extensions.Canvas.Model;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.Canvas.Infrastructure
{
    class ImageDataConverter : JsonConverter<ImageData>
    {
        public override ImageData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<ImageData>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, ImageData value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
