using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class RaiseRequest : NetworkMessage, IRequest
    {
        public string PlayerName { get; set; }
        public int Amount { get; set; }

        public RaiseRequest(string playerName, int amount)
        {
            this.PlayerName = playerName;
            this.Amount = amount;
        }
    }
}