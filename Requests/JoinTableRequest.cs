namespace Poker.Protocol.Requests
{
    public class JoinTableRequest : NetworkMessage, IRequest
    {
        public string RequestId { get; set; }
        public string PlayerName { get; set; }
        public string TableId { get; set; }
    }
}