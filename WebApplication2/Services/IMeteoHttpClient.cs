namespace WebApplication2.Services;

public interface IMeteoHttpClient
{
    Task<StationResponse> GetStation();
}
