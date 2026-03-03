using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class CheckRequest : NetworkMessage, IRequest
    {
        public string PlayerName { get; set; }

        public CheckRequest(string playerName)
        {
            this.PlayerName = playerName;
        }
    }
}