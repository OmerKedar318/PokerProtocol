namespace Poker.Protocol.DTOs
{
    public class WinnerDto
    {
        public string PlayerId { get; set; }
        public int AmountWon { get; set; }
        public string HandRankName { get; set; }
        public List<CardDto> WinningHand {  get; set; }

        public WinnerDto(string PlayerId, int AmountWon, string HandRankName, List<CardDto> WinningHand)
        {
            this.PlayerId = PlayerId;
            this.AmountWon = AmountWon;
            this.HandRankName = HandRankName;
            this.WinningHand = WinningHand;
        }
    }
}