using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class RaiseRequest : Request
    {
        private string PlayerName { get; set; }
        private int Amount { get; set; }

        public RaiseRequest(string playerName, int amount) : base(RequestType.RaiseRequest.type)
        {
            this.PlayerName = playerName;
            this.Amount = amount;
        }
    }
}