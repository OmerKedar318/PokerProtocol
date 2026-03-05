using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses
{
    public class GenericResponse : IResponse
    {
        private bool Success { get; set; }
        private string Error { get; set; }

        public GenericResponse(bool Success, string Error) 
        {
            this.Success = Success;
            this.Error = Error;
        }
    }
}