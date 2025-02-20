using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Tecoc.GetApis.Api.Models.Responses
{
    public class UserResponse
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name.first")]
        public string Name { get; set; }

        [JsonPropertyName("location.city")]
        public string Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("picture.large")]
        public string Picture { get; set; }

        [JsonPropertyName("nat")]
        public string Nat { get; set; }
    }
}
