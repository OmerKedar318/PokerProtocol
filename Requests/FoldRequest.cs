using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests;

public class FoldRequest : BaseRequest
{
    // Override the MsgType using your static constants class
    public override string MsgType => MessageType.FoldRequest;

    // Properties must be public for JSON serialization
    public string PlayerId { get; set; } = string.Empty;

    // Required for the JSON Deserializer
    public FoldRequest() { }

    public FoldRequest(string playerId)
    {
        PlayerId = playerId;
    }

    // This connects the network message to your GameEngine logic
    public override async Task ExecuteAsync(string connectionId, IGameService gameService)
    {
        // Tell the service that this connection wants to fold
        await gameService.HandleFoldAsync(connectionId, RequestId);
    }
}