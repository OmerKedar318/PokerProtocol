namespace Poker.Protocol.DTOs
{
    public class CardDto
    {
        // 0=Spades, 1=Hearts, 2=Diamonds, 3=Clubs
        private int Suit { get; set; }

        // 2-10 are face value, 11=J, 12=Q, 13=K, 14=A
        private int Rank { get; set; }

        public CardDto(int Suit, int Rank)
        {
            this.Suit = Suit;
            this.Rank = Rank;
        }

        public override string ToString() => $"{Rank} of {Suit}";
    }
}