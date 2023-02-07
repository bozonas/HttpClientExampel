namespace WebApplication2;

public class StationResponse
{
    public string code { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public Coordinates coordinates { get; set; }
}

public class Coordinates
{
    public float latitude { get; set; }
    public float longitude { get; set; }
}

