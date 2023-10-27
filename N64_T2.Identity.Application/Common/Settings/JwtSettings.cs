namespace N64_T2.Identity.Application.Common.Settings;

public class JwtSettings
{
    public bool ValidateIssuer { get; set; }
    public string ValidIssuer { get; set; }
    public bool ValidateAudiance { get; set; }
    public string ValidAudience { get; set; }
    public bool ValidateLifeTime { get; set; }
    public int ExpirationInMinutes { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public string SecretKey { get; set; }
}
