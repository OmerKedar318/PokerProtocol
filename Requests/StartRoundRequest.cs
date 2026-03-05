namespace Poker.Protocol.Requests
{
    public class StartRoundRequest : Request
    {
        public string TableId { get; set; }
        public StartRoundRequest(string tableId) : base(RequestType.StartRoundRequest.type)
        {
            this.TableId = tableId;
        }
    }
}