namespace Poker.Protocol.Requests
{
    public enum EventType {

        GameState("GameState"),
        GameEnded("GameEnded"),
        RoundEnded("RoundEnded"),

        public const string type;

        private Events(string type) {
            this.type = type;
        }
    }
}