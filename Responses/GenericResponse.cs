using Poker.Protocol.Abstractions;

namespace Poker.Protocol.Responses
{
    public class GenericResponse : NetworkMessage, IResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public GenericResponse(bool Success, string Error) 
        {
            this.Success = Success;
            this.Error = Error;
        }
    }
}