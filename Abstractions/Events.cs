namespace Poker.Protocol.Requests
{
    public enum Events {

        GameState("GameState"),
        GameEnded("GameEnded"),
        RoundEnded("RoundEnded"),

        public const string type;

        Events(string type) {
            this.type = type;
    }
}
}