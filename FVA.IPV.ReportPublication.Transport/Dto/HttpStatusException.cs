using System.Net;

namespace FVA.IPV.ReportPublication.Transport.Dto
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public HttpStatusException(HttpStatusCode status, string msg)
        {
            Status = status;
        }
    }
}
