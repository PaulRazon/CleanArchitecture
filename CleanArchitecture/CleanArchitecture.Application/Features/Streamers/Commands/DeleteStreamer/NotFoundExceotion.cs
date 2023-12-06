using System.Runtime.Serialization;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    [Serializable]
    internal class NotFoundExceotion : Exception
    {
        public NotFoundExceotion()
        {
        }

        public NotFoundExceotion(string? message) : base(message)
        {
        }

        public NotFoundExceotion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundExceotion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}