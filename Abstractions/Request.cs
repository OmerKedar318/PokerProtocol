namespace Poker.Protocol.Abstractions
using System.Security.Cryptography;
using .Requests;
using System.Text.Json.Serialization;

public abstract class Request {

    [JsonPropertyName("id")]
    public const string RequestId;

    [JsonPropertyName("type")]
    public const RequestType type;

    [JsonPropertyName("ts")]
    public const long Timestamp;


    Request(RequestType type) {
            this.RequestId = Convert.ToHexString(RandomNumberGenerator.GetBytes(16));
            this.type = type;
            this.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}