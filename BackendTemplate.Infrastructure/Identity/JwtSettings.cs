namespace BackendTemplate.Infrastructure.Identity
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; } = null!;
        public string ValidAudiences { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public int Expires { get; set; }
    }
}
