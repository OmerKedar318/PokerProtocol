using System.Security.Cryptography;
using .RequestType;
using System.Text.Json.Serialization;

namespace Poker.Protocol.Abstractions 
{
    public abstract class Request {
        [JsonPropertyName("id")]
        public const string RequestId;

        [JsonPropertyName("type")]
        public const RequestType type;

        [JsonPropertyName("ts")]
        public const long Timestamp;


        public Request(RequestType type)
        {
            this.RequestId = Convert.ToHexString(RandomNumberGenerator.GetBytes(16));
            this.type = type;
            this.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}