namespace Poker.Protocol.Abstractions
{
    public abstract class NetworkMessage
    {
        public string MessageType => this.GetType().Name;
        public string MessageId { get; set; }
        public long Timestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}