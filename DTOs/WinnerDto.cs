namespace Poker.Protocol.DTOs
{
    public class WinnerDto
    {
        private string PlayerId { get; set; }
        private int AmountWon { get; set; }
        private string HandRankName { get; set; }
        private List<CardDto> WinningHand {  get; set; }

        public WinnerDto(string PlayerId, int AmountWon, string HandRankName, List<CardDto> WinningHand)
        {
            this.PlayerId = PlayerId;
            this.AmountWon = AmountWon;
            this.HandRankName = HandRankName;
            this.WinningHand = WinningHand;
        }
    }
}