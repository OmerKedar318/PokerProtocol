using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Requests
{
    public class StartRoundRequest : Request
    {
        private string TableId { get; set; }

        public StartRoundRequest(string tableId) : base(RequestType.StartRoundRequest)
        {
            this.TableId = tableId;
        }
    }
}