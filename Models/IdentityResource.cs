namespace IdentityServer.Models;

public class IdentityResource
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public bool Required { get; set; }
    public bool Emphasize { get; set; }
    public bool ShowInDiscoveryDocument { get; set; } = true;
    public List<string> UserClaims { get; set; } = new();
    public Dictionary<string, string> Properties { get; set; } = new();
    public bool IsStandard { get; set; } // openid, profile, email, phone, address
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
