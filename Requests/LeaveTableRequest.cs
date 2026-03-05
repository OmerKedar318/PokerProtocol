using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class LeaveTableRequest : Request
    {
        private string PlayerName { get; set; }

        public LeaveTableRequest(string playerName) : base(RequestType.LeaveTableRequest.type)
        {
            this.PlayerName = playerName;
        }
    }
}