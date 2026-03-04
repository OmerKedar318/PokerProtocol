using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class BetRequest : NetworkMessage, IRequest
    {
        public string PlayerName { get; set; }

        public BetRequest(string playerName)
        {
            this.PlayerName = playerName;
        }
    }
}