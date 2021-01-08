using Newtonsoft.Json;

namespace HostedService.API.Services.ComicService
{
    public class Comic
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("transcript")]
        public string Text { get; set; }

        [JsonProperty("img")]
        public string ImageUrl { get; set; }

        [JsonProperty("alt")]
        public string ImageAlt { get; set; }
    }
}