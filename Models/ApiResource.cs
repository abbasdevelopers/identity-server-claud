namespace IdentityServer.Models;

public class ApiResource
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public bool ShowInDiscoveryDocument { get; set; } = true;
    public List<string> Scopes { get; set; } = new();
    public List<string> UserClaims { get; set; } = new();
    public List<ApiSecret> ApiSecrets { get; set; } = new();
    public Dictionary<string, string> Properties { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class ApiSecret
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Value { get; set; } = string.Empty;
    public string Type { get; set; } = "SharedSecret";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
}
