namespace Poker.Protocol.Abstractions
{
public static class MessageType
{
    // Requests (Client -> Server)
    public const string JoinTableRequest = "JoinTableRequest";
    public const string BetRequest = "BetRequest";
    public const string FoldRequest = "FoldRequest";
    public const string RaiseRequest = "RaiseRequest";
    public const string StartRoundRequest = "StartRoundRequest";

    // Responses (Server -> Client - Direct)
    public const string JoinTableResponse = "JoinTableResponse";
    public const string GenericResponse = "GenericResponse";

    // Events (Server -> Client - Broadcast)
    public const string GameStateEvent = "GameStateEvent";
    public const string PrivateCardsEvent = "PrivateCardsEvent";
    public const string RoundEndEvent = "RoundEndEvent";
}
}
