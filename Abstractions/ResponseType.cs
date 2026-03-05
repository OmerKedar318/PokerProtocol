namespace Poker.Protocol.Abstractions
{
    public enum ResponseType
    {
        Generic("Generic"),
        JoinTable("JoinTable"),

        public const string type;
        private ResponseType(string type)
        {
            this.type = type;
        }
    }
}