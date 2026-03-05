using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class FoldRequest : Request
    {
        private string PlayerId { get; set; }

        public FoldRequest(string playerId) : base(RequestType.FoldRequest.type)
        {
            this.PlayerId = playerId;
        }
    }
}