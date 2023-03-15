using System.ComponentModel.DataAnnotations;

namespace FVA.IPV.ReportPublication.Model.Configuration
{
    public class ReportNameSpaceConfiguration
    {
        public static string SectionName => "ReportNameSpaceConfiguration";

        [Required]
        public string? Url { get; set; }

        [Required]
        public string? PublisherName { get; set; }

        [Required]
        public string? BucketId { get; set; }

        [Required]
        public string[]? ReadAuthority { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ReportNameSpaceConfiguration configuration &&
                   Url == configuration.Url &&
                   PublisherName == configuration.PublisherName &&
                   BucketId == configuration.BucketId &&
                   EqualityComparer<string[]>.Default.Equals(ReadAuthority, configuration.ReadAuthority);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
