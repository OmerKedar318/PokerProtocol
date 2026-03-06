using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace Poker.Protocol.Abstractions
{
    public abstract class Response {
        [JsonPropertyName("success")]
        public readonly bool Success;

        [JsonPropertyName("type")]
        public readonly ResponseType type;

        public Response(ResponseType type, string RequestId)
        {
            this.Success = Success;
            this.type = type;
        }
    }
}