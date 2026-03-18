using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses;

public class GenericResponse : BaseResponse
{
    // Override with the constant from your MessageTypes class
    public override string MsgType => MessageType.GenericResponse;

    // These must be public so the client's JSON parser can read them
    // Note: We inherit 'RequestId', 'Success', and 'ErrorMessage' from BaseResponse!

    // Required for the JSON Deserializer
    public GenericResponse() { }

    public GenericResponse(string requestId, bool success, string? errorMessage = null)
    {
        RequestId = requestId;
        Success = success;
        ErrorMessage = errorMessage;
    }
}