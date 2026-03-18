using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses;

public class JoinTableResponse : BaseResponse
{
    // Override with the constant from your MessageTypes class
    public override string MsgType => MessageType.JoinTableResponse;

    // Specific data for joining a table
    public string AssignedSeatId { get; set; } = string.Empty;
    public bool IsHost { get; set; }

    // Required for the JSON Deserializer
    public JoinTableResponse() { }

    public JoinTableResponse(
        string requestId,
        bool success,
        string? errorMessage,
        string assignedSeatId,
        bool isHost)
    {
        // These belong to the BaseResponse
        RequestId = requestId;
        Success = success;
        ErrorMessage = errorMessage;

        // These are unique to JoinTableResponse
        AssignedSeatId = assignedSeatId;
        IsHost = isHost;
    }
}