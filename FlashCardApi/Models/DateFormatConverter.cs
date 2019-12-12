using System;
using System.Buffers.Text;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlashCardApi.Models
{
    public class DateFormatConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetInt64(out long timestampInMilliseconds))
            {
                DateTime result = DateTime.UnixEpoch.AddMilliseconds(timestampInMilliseconds);
                return result;
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            TimeSpan timeSpan = value.ToUniversalTime() - DateTime.UnixEpoch;
            double timestampInMilliseconds = timeSpan.TotalMilliseconds;

            writer.WriteNumberValue(timestampInMilliseconds);
        }
    }
}
