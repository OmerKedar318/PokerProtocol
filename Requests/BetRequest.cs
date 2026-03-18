using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class BetRequest : Request
    {
        private string PlayerName { get; set; }

        public BetRequest(string playerName) : base(RequestType.BetRequest)
        {
            this.PlayerName = playerName;
        }
    }
}