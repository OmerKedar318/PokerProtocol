using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses
{
    public class JoinTableResponse : IResponse
    {
        private string RequestId { get; set; } // Matches the RequestId from JoinTableRequest
        private bool Success { get; set; }
        private string ErrorMessage { get; set; }
        private string AssignedSeatId { get; set; }
        private bool IsHost {get; set; }

        public JoinTableResponse(string requestId, bool success, string errorMessage, string assignedSeatId, bool IsHost) 
        {
            this.RequestId = requestId;
            this.Success = success;
            this.ErrorMessage = errorMessage;
            this.AssignedSeatId = assignedSeatId;
            this.IsHost = IsHost;
        }
    }

}
