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
                DateTime result = Epoch().AddMilliseconds(timestampInMilliseconds);
                return result;
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            TimeSpan timeSpan = value.ToUniversalTime() - Epoch();
            double timestampInMilliseconds = timeSpan.TotalMilliseconds;

            writer.WriteNumberValue(timestampInMilliseconds);
        }

        /**
         * Epoch time is January 1st 1970 UTC.
         */
        private DateTime Epoch()
        {
            return new DateTime(1970, 1, 1).ToUniversalTime();
        }
    }
}
