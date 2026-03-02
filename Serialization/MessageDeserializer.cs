using System.Text.Json;
using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Serialization
{
    public static class MessageDeserializer
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static NetworkMessage Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);

            // Check if the property "MessageType" exists in the JSON
            if (!doc.RootElement.TryGetProperty("MessageType", out var typeProp))
                return null;

            string typeName = typeProp.GetString();
            Type targetType = MessageRegistry.GetTypeForMessage(typeName);

            if (targetType == null)
                throw new Exception($"Unknown message type: {typeName}");

            return (NetworkMessage)JsonSerializer.Deserialize(json, targetType, _options);
        }
    }
}