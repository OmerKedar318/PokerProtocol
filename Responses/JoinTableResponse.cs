using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses
{
    public class JoinTableResponse : NetworkMessage, IResponse
    {
        public string RequestId { get; set; } // Matches the RequestId from JoinTableRequest
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string AssignedSeatId { get; set; }

        public JoinTableResponse(string requestId, bool success, string errorMessage, string assignedSeatId) 
        {
            this.RequestId = requestId;
            this.Success = success;
            this.ErrorMessage = errorMessage;
            this.AssignedSeatId = assignedSeatId;
        }
    }
}