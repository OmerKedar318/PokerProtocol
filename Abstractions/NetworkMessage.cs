using System.Text.Json.Serialization;
using Poker.Protocol.Requests;
using Poker.Protocol.Responses;
using Poker.Protocol.Events;

namespace Poker.Protocol.Abstractions;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "MessageType")]
// --- Mapping Requests ---
[JsonDerivedType(typeof(JoinTableRequest), MessageType.JoinTableRequest)]
[JsonDerivedType(typeof(BetRequest), MessageType.BetRequest)]
[JsonDerivedType(typeof(FoldRequest), MessageType.FoldRequest)]
[JsonDerivedType(typeof(RaiseRequest), MessageType.RaiseRequest)]
[JsonDerivedType(typeof(StartRoundRequest), MessageType.StartRoundRequest)]

// --- Mapping Responses ---
[JsonDerivedType(typeof(JoinTableResponse), MessageType.JoinTableResponse)]
[JsonDerivedType(typeof(GenericResponse), MessageType.GenericResponse)]

// --- Mapping Events ---
[JsonDerivedType(typeof(GameStateEvent), MessageType.GameStateEvent)]
[JsonDerivedType(typeof(PrivateCardsEvent), MessageType.PrivateCardsEvent)]
[JsonDerivedType(typeof(RoundEndEvent), MessageType.RoundEndEvent)]

public abstract class NetworkMessage
{
    // This MUST be abstract or virtual
    [JsonPropertyName("MessageType")]
    public abstract string MsgType { get; }

    public long Timestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}

public interface IRequestHandler
{
    // Every request will implement this to talk to the Server's Game Logic
    Task ExecuteAsync(string connectionId, IGameService gameService);
}

// 1. Requests: Sent by Client -> Server
public abstract class BaseRequest : NetworkMessage, IRequestHandler
{
    public string RequestId { get; set; }
    public abstract Task ExecuteAsync(string connectionId, IGameService gameService);
}

// 2. Responses: Sent by Server -> Client (Direct answer to a Request)
public abstract class BaseResponse : NetworkMessage
{
    public string RequestId { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

// 3. Events: Sent by Server -> Client (Broadcast updates)
public abstract class BaseEvent : NetworkMessage { }