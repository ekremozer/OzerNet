using Microsoft.AspNetCore.Http;

namespace OzerNet.Commands.Infrastructure
{
    public abstract class Command
    {
        #region DefaultProperties
        public HttpRequest HttpRequest { get; set; } = null;
        public string ClientIpAddress { get; set; }
        public bool IsPaging { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public bool IsSorting { get; set; } = false;
        public string OrderDirection { get; set; } = "CreatedDate";
        public string OrderField { get; set; } = "DESC";
        public bool ClearCache { get; set; } = false;
        #endregion
    }
}
