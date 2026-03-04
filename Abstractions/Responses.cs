namespace Poker.Protocol.Requests
{
    public enum ResponseType
    {
        Generic("Generic"),
        JoinTable("JoinTable"),

        public const string type;
        ResponseType(string type)
        {
            this.type = type;
    }
}
}