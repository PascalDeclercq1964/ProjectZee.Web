namespace ProjectZee.Web.Services
{
    using System.Net.Http.Json;

    public class CmsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _umbracoBaseUrl = "https://documentatie.cameleonsoftware.be";

        public CmsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CmsContentItem?> GetPageAsync(string path)
        {
            var client = _httpClientFactory.CreateClient("UmbracoCms");

            CmsContentItem returnItem = new CmsContentItem { Content = new ContentField { Markup = "..." }, Title = "..." };

            try
            {
                var response = await client.GetAsync($"{_umbracoBaseUrl}/umbraco/delivery/api/v1/content/item/paz/{path.TrimStart('/')}");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<UmbracoItemResponse>();
                    returnItem = data.Properties;
                }
            }
            catch { } // we suffer in silence ..
            return returnItem;
        }

        private string? ExtractImageUrl(object? propertyValue)
        {
            // Logica om de URL uit de Umbraco Media picker JSON te vissen
            // v13 geeft vaak een array van media objecten terug
            return propertyValue?.ToString();
        }
    }

    public class UmbracoItemResponse
    {
        public string Name { get; set; } = string.Empty;
        public CmsContentItem Properties { get; set; } = new();
    }

    public class CmsContentItem
    {
        public string Title { get; set; } = string.Empty;
        public ContentField Content { get; set; } = new();
    }

    public class ContentField
    {
        public string Markup { get; set; } = string.Empty;
    }


}
