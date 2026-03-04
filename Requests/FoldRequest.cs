using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class FoldRequest : IRequest
    {
        public string PlayerId { get; set; }

        public FoldRequest(string playerId)
        {
            this.PlayerId = playerId;
        }
    }
}