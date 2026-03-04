using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class LeaveTableRequest : Request
    {
        public string PlayerName { get; set; }

        public LeaveTableRequest(string playerName) 
        {
            this.PlayerName = playerName;
        }
    }
}