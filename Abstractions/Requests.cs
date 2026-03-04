namespace Poker.Protocol.Abstractions
{
    public enum RequestType {
        BetRequest("BetRequest"),
        FoldRequest("FoldRequest"),
        JoinTableRequest("JoinTableRequest"),
        LeaveTableRequest("LeaveTableRequest"),
        StartRoundRequest("StartRoundRequest"),
        RaiseRequest("RaiseRequest"),

        public const string type;
        RequestType(string type) {
            this.type = type;
        } 
    }
}