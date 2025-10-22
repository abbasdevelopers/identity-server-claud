namespace IdentityServer.Models;

public class Client
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ClientId { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ClientType { get; set; } = "Web"; // Web, SPA, Native, Machine
    public string LogoUri { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public bool RequireClientSecret { get; set; } = true;
    public bool RequirePkce { get; set; } = true;
    public bool AllowOfflineAccess { get; set; } = true;
    public int AccessTokenLifetime { get; set; } = 3600;
    public int RefreshTokenLifetime { get; set; } = 2592000;
    public List<string> AllowedScopes { get; set; } = new();
    public List<string> RedirectUris { get; set; } = new();
    public List<string> PostLogoutRedirectUris { get; set; } = new();
    public List<string> AllowedCorsOrigins { get; set; } = new();
    public List<string> AllowedGrantTypes { get; set; } = new();
    public List<ClientSecret> ClientSecrets { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastUsed { get; set; }
    public int TotalRequests { get; set; }
}

public class ClientSecret
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Value { get; set; } = string.Empty; // Hashed
    public string Type { get; set; } = "SharedSecret";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }

    public string PartialValue => Value.Length > 10 ? $"***{Value.Substring(Value.Length - 6)}" : "***";
}
