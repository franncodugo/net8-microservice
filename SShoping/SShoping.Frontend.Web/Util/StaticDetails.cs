namespace SShoping.Frontend.Web.Util;

public sealed class StaticDetails
{
    public static string CouponAPIBaseUrl { get; set; }

    public enum ApiType
    {
        GET,
        POST, 
        PUT, 
        DELETE
    }
}
