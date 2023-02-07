namespace WebApplication2.Services;

public class MeteoHttpClient : IMeteoHttpClient
{
    private readonly HttpClient _httpClient;

    public MeteoHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.meteo.lt/v1/");
    }

    public async Task<StationResponse> GetStation()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("stations/vilniaus-ams");
        response.EnsureSuccessStatusCode();

        var stationResponse = await response.Content
            .ReadFromJsonAsync<StationResponse>();

        return stationResponse;
    }
}
