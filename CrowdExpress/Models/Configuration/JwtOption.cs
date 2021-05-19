using AuthWebApi.Contract.Contract;

namespace CrowdExpress.Models.Configuration
{
    public class JwtOption : IJwtOptions
    {
        public const string Section = "JwtTokens";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
