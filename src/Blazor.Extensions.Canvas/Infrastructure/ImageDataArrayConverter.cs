using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.Canvas.Infrastructure
{
    class ImageDataArrayConverter : JsonConverter<byte[]>
    {
        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Dictionary<string, byte> dictionary = JsonSerializer.Deserialize<Dictionary<string, byte>>(ref reader, options);
            return dictionary.Values.ToArray<byte>();
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            for(int i = 0; i < value.Length; i++)
            {
                writer.WritePropertyName(i.ToString());
                JsonSerializer.Serialize(writer, value[i], options);
            }
            writer.WriteEndObject();
        }
    }
}
