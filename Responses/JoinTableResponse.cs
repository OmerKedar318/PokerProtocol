using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses
{
    public class JoinTableResponse : IResponse
    {
        private string RequestId { get; set; } // Matches the RequestId from JoinTableRequest
        private bool Success { get; set; }
        private string ErrorMessage { get; set; }
        private string AssignedSeatId { get; set; }

        public JoinTableResponse(string requestId, bool success, string errorMessage, string assignedSeatId) 
        {
            this.RequestId = requestId;
            this.Success = success;
            this.ErrorMessage = errorMessage;
            this.AssignedSeatId = assignedSeatId;
        }
    }
}