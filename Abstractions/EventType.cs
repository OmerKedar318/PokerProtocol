namespace Poker.Protocol.Abstractions
{

    public sealed record EventType
    {
        public static readonly EventType GameState = new EventType("GameState");
        public static readonly EventType PrivateCards = new EventType("PrivateCards");
        public static readonly EventType RoundEnd = new EventType("RoundEnd");

        public string Type { get; }

        private EventType(string type)
        {
            Type = type;
        }

        public override string ToString() => Type;
    }
}