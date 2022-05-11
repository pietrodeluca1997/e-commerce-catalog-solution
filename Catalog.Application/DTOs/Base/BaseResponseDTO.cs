using System.Net;

namespace Catalog.Application.DTOs.Base
{
    public abstract class BaseResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; } = string.Empty;
        public DateTime ResponseTime { get; } = DateTime.Now;
        public abstract bool Success { get; }
    }
}
