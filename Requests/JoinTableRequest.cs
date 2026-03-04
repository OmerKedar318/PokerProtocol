using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class JoinTableRequest : Request
    {
        public string PlayerName { get; set; }
        public string TableId { get; set; }

        public JoinTableRequest(string playerName, string tableId) 
        {
            this.PlayerName = playerName;
            this.TableId = tableId;
        }
    }
}