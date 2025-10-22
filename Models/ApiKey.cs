namespace IdentityServer.Models;

public class ApiKey
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty; // The actual key (hashed in production)
    public string PartialKey => Key.Length > 10 ? $"sk_***{Key.Substring(Key.Length - 6)}" : "sk_***";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
    public DateTime? LastUsed { get; set; }
    public string Status { get; set; } = "Active"; // Active, Expired, Revoked
    public List<string> Scopes { get; set; } = new();
    public List<string> IpWhitelist { get; set; } = new();
    public int RequestCount { get; set; }
}
