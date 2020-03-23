namespace ItinerarioSNC.Infra.CrossCutting
{

    public class User
    {
        public string UserId { get; set; }
        public string AccessKey { get; set; }
    }

    public class JWTCOnfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
