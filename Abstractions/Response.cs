using System.Security.Cryptography;
using .ResponseType;
using System.Text.Json.Serialization;

namespace Poker.Protocol.Abstractions
{
    public abstract class Response {
        [JsonPropertyName("success")]
        public const bool Success;

        [JsonPropertyName("type")]
        public const ResponseType type;

        [JsonPropertyName("error")]
        public const string Error;

        [JsonPropertyName("request id")]
        public const string RequestId;

        public Response(bool Success, ResponseType type, string Error, string RequestId)
        {
            this.Success = Success;
            this.type = type;
            this.Error = Error;
            this.RequestId = RequestId;
        }
    }
}