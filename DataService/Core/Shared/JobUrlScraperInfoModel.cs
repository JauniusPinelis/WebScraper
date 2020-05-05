using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WebScraper.Core.Shared
{
    public class JobUrlScraperInfoModel
    {

        public string Url { get; set; }
        public string? UrlAttribute { get; set; }
        public string Title { get; set; }
        public string? TitleAttribute { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string? LocationAttribute { get; set; }
        public string Company { get; set; }

        public string? LogoAttribute { get; set; }
        public string Logo { get; set; }

    }
}
