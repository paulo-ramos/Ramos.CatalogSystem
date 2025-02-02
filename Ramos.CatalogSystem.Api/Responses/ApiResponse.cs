using Microsoft.AspNetCore.Mvc;

namespace Ramos.CatalogSystem.Api.Responses;

public class ApiResponse<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public DateTime RequestDate { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public string? TraceId { get; set; }

}