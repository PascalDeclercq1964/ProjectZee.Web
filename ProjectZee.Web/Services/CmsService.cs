namespace ProjectZee.Web.Services
{
    using System.Net.Http.Json;

    //https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/headless-and-apis/content-delivery-api
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

        //om items op te halen, bv voor de homepage, kunnen we ook de children van een item ophalen, en daaruit de juiste content vissen
        //https://documentatie.cameleonsoftware.be/umbraco/delivery/api/v1/content?fetch=children:3057a2fe-5707-4a90-88fe-cbfbe68fadcc

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
