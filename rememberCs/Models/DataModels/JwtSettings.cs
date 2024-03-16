namespace rememberCs.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigningKey { get; set; }
        public string IssuerSigningKey { get; set; } = string.Empty;
        public bool validateIUssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }
        public bool ValidateAudience {  get; set; }
        public string? ValidAudience { get; set;}


        public bool RequireExpirationTime {  get; set; }
        public bool ValidateLifetime { get; set; } = true;


    }
}
