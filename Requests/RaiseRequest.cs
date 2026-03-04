using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class RaiseRequest : Request
    {
        public string PlayerName { get; set; }
        public int Amount { get; set; }

        public RaiseRequest(string playerName, int amount) : base(RequestType.RaiseRequest.type)
        {
            this.PlayerName = playerName;
            this.Amount = amount;
        }
    }
}