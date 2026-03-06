namespace Poker.Protocol.DTOs
{
    public class GameStateDto
    {
        private List<PlayerStateDto> Players { get; set; }
        private List<CardDto> Deck { get; set; } = new List<CardDto>();
        private List<CardDto> CommunityCards { get; set; }
        private int PotSize { get; set; }
        private int CurrentBet { get; set; }
        private string ActivePlayerId { get; set; }
        private GameStage Stage { get; set; } // Enum: PreFlop, Flop, etc.

        public GameStateDto()
        {
            Players = new List<PlayerStateDto>();
            for (int i = 2; i < 15; i++)
            {
                Deck.Add(new CardDto(i, 0));
                Deck.Add(new CardDto(i, 1));
                Deck.Add(new CardDto(i, 2));
                Deck.Add(new CardDto(i, 3));
            }
            CommunityCards = new List<CardDto>();
            PotSize = 0;
            CurrentBet = 0;
            ActivePlayerId = "";
            Stage = null; // Change!
        }

        public void Shuffle()
        {
            for (int i = Deck.Count - 1; i > 0; i--)
            {
                Random rand = new Random();
                int j = rand.Next(0, i);
                CardDto temp = Deck[i];
                Deck[i] = Deck[j];
                Deck[j] = temp;
            }
        }

        public CardDto DealSingleCard()
        {
            CardDto dealt = Deck[Deck.Count - 1];
            Deck.RemoveAt(Deck.Count - 1);
            return dealt;
        }
    }

    public sealed record GameStage
    {

    }
}