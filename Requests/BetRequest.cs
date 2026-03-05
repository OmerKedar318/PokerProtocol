using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class BetRequest : Request
    {
        public string PlayerName { get; set; }

        public BetRequest(string playerName) : base(RequestType.BetRequest.type)
        {
            this.PlayerName = playerName;
        }
    }
}