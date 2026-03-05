using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class JoinTableRequest : Request
    {
        private string PlayerName { get; set; }
        private string TableId { get; set; }

        public JoinTableRequest(string playerName, string tableId) : base(RequestType.JoinTableRequest.type)
        {
            this.PlayerName = playerName;
            this.TableId = tableId;
        }
    }
}