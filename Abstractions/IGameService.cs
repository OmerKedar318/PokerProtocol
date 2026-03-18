namespace Poker.Protocol.Abstractions
{
    public interface IGameService
    {
        // Just define the signatures for now
        Task HandleJoinTableAsync(string connectionId, string tableId, string playerName, string requestId);
        Task HandleBetAsync(string connectionId, int amount, string requestId);
        Task HandleFoldAsync(string connectionId, string requestId);
        Task HandleStartRoundAsync(string connectionId, string requestId);
        Task HandleLeaveTableAsync(string connectionId, string tableId, string requestId);
    }
}
