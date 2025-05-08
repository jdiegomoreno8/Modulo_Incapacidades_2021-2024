using Newtonsoft.Json;

namespace LibreriasAutorizaciones.Modelos.DTO

{
    public class TokenManagement
    {
        [JsonProperty("Security")]
        public string Security { get; set; }

        [JsonProperty("Issuer")]
        public string Issuer { get; set; }

        [JsonProperty("Audience")]
        public string Audience { get; set; }

        [JsonProperty("AccessTokenExpireTime")]
        public int AccessTokenExpireTime { get; set; }

        [JsonProperty("RefreshTokenExpireTime")]
        public int RefreshTokenExpireTime { get; set; }
    }
}