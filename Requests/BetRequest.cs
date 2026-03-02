using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class BetRequest : NetworkMessage, IRequest
    {
        public string RequestId { get; set; }
        public int Amount { get; set; }
    }
}