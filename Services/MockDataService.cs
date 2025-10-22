using IdentityServer.Models;

namespace IdentityServer.Services;

public class MockDataService
{
    public List<User> Users { get; set; } = new();
    public List<Client> Clients { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
    public List<ApiResource> ApiResources { get; set; } = new();
    public List<IdentityResource> IdentityResources { get; set; } = new();
    public List<Scope> Scopes { get; set; } = new();
    public List<AuditLog> AuditLogs { get; set; } = new();
    public List<UserSession> UserSessions { get; set; } = new();
    public List<ApiKey> ApiKeys { get; set; } = new();

    public MockDataService()
    {
        InitializeRoles();
        InitializeUsers();
        InitializeIdentityResources();
        InitializeApiResources();
        InitializeScopes();
        InitializeClients();
        InitializeAuditLogs();
        InitializeUserSessions();
        InitializeApiKeys();
    }

    private void InitializeRoles()
    {
        Roles = new List<Role>
        {
            new Role
            {
                Id = "role-1",
                Name = "Admin",
                DisplayName = "Administrator",
                Description = "Full system access with all permissions",
                RoleType = "System",
                UserCount = 5,
                Permissions = new List<string> { "users.create", "users.read", "users.update", "users.delete", "roles.manage", "clients.manage", "api.manage", "config.manage", "logs.read" }
            },
            new Role
            {
                Id = "role-2",
                Name = "Developer",
                DisplayName = "Developer",
                Description = "API and client management access",
                RoleType = "Custom",
                UserCount = 12,
                Permissions = new List<string> { "clients.create", "clients.read", "clients.update", "api.read", "api.create" }
            },
            new Role
            {
                Id = "role-3",
                Name = "Manager",
                DisplayName = "Manager",
                Description = "User and role management access",
                RoleType = "Custom",
                UserCount = 8,
                Permissions = new List<string> { "users.read", "users.update", "roles.read", "roles.assign" }
            },
            new Role
            {
                Id = "role-4",
                Name = "Support",
                DisplayName = "Support Specialist",
                Description = "Read-only access with user unlock capability",
                RoleType = "Custom",
                UserCount = 15,
                Permissions = new List<string> { "users.read", "users.unlock", "logs.read" }
            },
            new Role
            {
                Id = "role-5",
                Name = "ApiConsumer",
                DisplayName = "API Consumer",
                Description = "Limited API access for external integrations",
                RoleType = "Custom",
                UserCount = 45,
                Permissions = new List<string> { "api.read" }
            },
            new Role
            {
                Id = "role-6",
                Name = "User",
                DisplayName = "Standard User",
                Description = "Basic application access",
                RoleType = "System",
                UserCount = 230,
                Permissions = new List<string> { "profile.read", "profile.update" }
            },
            new Role
            {
                Id = "role-7",
                Name = "Auditor",
                DisplayName = "Auditor",
                Description = "Read-only access to audit logs and analytics",
                RoleType = "Custom",
                UserCount = 6,
                Permissions = new List<string> { "logs.read", "analytics.view", "users.read" }
            },
            new Role
            {
                Id = "role-8",
                Name = "TechLead",
                DisplayName = "Technical Lead",
                Description = "Technical leadership with broad permissions",
                RoleType = "Custom",
                UserCount = 4,
                Permissions = new List<string> { "clients.manage", "api.manage", "users.read", "config.read" }
            }
        };
    }

    private void InitializeUsers()
    {
        var random = new Random();
        var firstNames = new[] { "John", "Jane", "Bob", "Alice", "Charlie", "Diana", "Eve", "Frank", "Grace", "Henry", "Ivy", "Jack", "Kate", "Leo", "Mary", "Nathan", "Olivia", "Paul", "Quinn", "Rachel", "Sam", "Tina", "Uma", "Victor", "Wendy", "Xavier", "Yara", "Zack", "Emma", "Liam", "Sophia", "Noah", "Ava", "Mason", "Isabella", "William", "Mia", "James", "Charlotte", "Benjamin", "Amelia", "Lucas", "Harper", "Henry", "Evelyn", "Alexander", "Abigail", "Michael", "Emily", "Daniel" };
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts" };
        var locations = new[] { "New York, NY", "Los Angeles, CA", "Chicago, IL", "Houston, TX", "Phoenix, AZ", "Philadelphia, PA", "San Antonio, TX", "San Diego, CA", "Dallas, TX", "San Jose, CA", "Austin, TX", "Jacksonville, FL", "Fort Worth, TX", "Columbus, OH", "Charlotte, NC", "San Francisco, CA", "Indianapolis, IN", "Seattle, WA", "Denver, CO", "Boston, MA" };

        Users = new List<User>();

        // Add admin user
        Users.Add(new User
        {
            Id = "user-1",
            Username = "admin",
            Email = "admin@identityserver.com",
            FirstName = "Admin",
            LastName = "User",
            PhoneNumber = "+1 (555) 123-4567",
            AvatarUrl = "https://ui-avatars.com/api/?name=Admin+User&background=2563eb&color=fff",
            EmailConfirmed = true,
            PhoneConfirmed = true,
            TwoFactorEnabled = true,
            LockoutEnabled = false,
            CreatedAt = DateTime.UtcNow.AddMonths(-6),
            LastLogin = DateTime.UtcNow.AddHours(-2),
            LastLoginLocation = "San Francisco, CA",
            LastLoginIp = "192.168.1.100",
            Roles = new List<string> { "Admin" },
            Bio = "System administrator with full access to all features and configurations.",
            Status = "Active"
        });

        // Generate 60 more users with diverse data
        for (int i = 2; i <= 60; i++)
        {
            var firstName = firstNames[random.Next(firstNames.Length)];
            var lastName = lastNames[random.Next(lastNames.Length)];
            var username = $"{firstName.ToLower()}.{lastName.ToLower()}{(i > 20 ? i.ToString() : "")}";
            var email = $"{username}@example.com";
            var rolesList = new List<string>();

            // Assign roles based on distribution
            if (i <= 5) rolesList.Add("Admin");
            else if (i <= 17) rolesList.Add("Developer");
            else if (i <= 25) rolesList.Add("Manager");
            else if (i <= 40) rolesList.Add("Support");
            else if (i <= 50) rolesList.Add("ApiConsumer");
            else rolesList.Add("User");

            var statuses = new[] { "Active", "Active", "Active", "Active", "Active", "Locked", "Suspended" };
            var status = statuses[random.Next(statuses.Length)];

            Users.Add(new User
            {
                Id = $"user-{i}",
                Username = username,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = $"+1 ({random.Next(200, 999)}) {random.Next(100, 999)}-{random.Next(1000, 9999)}",
                AvatarUrl = $"https://ui-avatars.com/api/?name={firstName}+{lastName}&background={random.Next(0, 16777215):X6}&color=fff",
                EmailConfirmed = random.Next(0, 10) > 1,
                PhoneConfirmed = random.Next(0, 10) > 3,
                TwoFactorEnabled = random.Next(0, 10) > 6,
                LockoutEnabled = status == "Locked",
                LockoutEnd = status == "Locked" ? DateTime.UtcNow.AddHours(random.Next(1, 24)) : null,
                AccessFailedCount = status == "Locked" ? random.Next(3, 10) : 0,
                CreatedAt = DateTime.UtcNow.AddDays(-random.Next(1, 365)),
                LastLogin = DateTime.UtcNow.AddHours(-random.Next(1, 720)),
                LastLoginLocation = locations[random.Next(locations.Length)],
                LastLoginIp = $"{random.Next(10, 192)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(1, 255)}",
                Roles = rolesList,
                Bio = $"Professional {rolesList[0]} with expertise in identity management and security.",
                Status = status
            });
        }
    }

    private void InitializeIdentityResources()
    {
        IdentityResources = new List<IdentityResource>
        {
            new IdentityResource
            {
                Id = "ir-1",
                Name = "openid",
                DisplayName = "OpenID",
                Description = "Your user identifier",
                Enabled = true,
                Required = true,
                IsStandard = true,
                UserClaims = new List<string> { "sub" }
            },
            new IdentityResource
            {
                Id = "ir-2",
                Name = "profile",
                DisplayName = "User Profile",
                Description = "Your user profile information (name, picture, etc.)",
                Enabled = true,
                IsStandard = true,
                UserClaims = new List<string> { "name", "family_name", "given_name", "middle_name", "nickname", "preferred_username", "profile", "picture", "website", "gender", "birthdate", "zoneinfo", "locale", "updated_at" }
            },
            new IdentityResource
            {
                Id = "ir-3",
                Name = "email",
                DisplayName = "Email Address",
                Description = "Your email address",
                Enabled = true,
                Emphasize = true,
                IsStandard = true,
                UserClaims = new List<string> { "email", "email_verified" }
            },
            new IdentityResource
            {
                Id = "ir-4",
                Name = "phone",
                DisplayName = "Phone Number",
                Description = "Your phone number",
                Enabled = true,
                IsStandard = true,
                UserClaims = new List<string> { "phone_number", "phone_number_verified" }
            },
            new IdentityResource
            {
                Id = "ir-5",
                Name = "address",
                DisplayName = "Address",
                Description = "Your postal address",
                Enabled = true,
                IsStandard = true,
                UserClaims = new List<string> { "address" }
            },
            new IdentityResource
            {
                Id = "ir-6",
                Name = "roles",
                DisplayName = "User Roles",
                Description = "Your assigned roles and permissions",
                Enabled = true,
                IsStandard = false,
                UserClaims = new List<string> { "role" }
            }
        };
    }

    private void InitializeApiResources()
    {
        ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Id = "api-1",
                Name = "orders-api",
                DisplayName = "Orders API",
                Description = "API for managing customer orders and order processing",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "orders.read", "orders.write", "orders.delete" },
                UserClaims = new List<string> { "sub", "name", "email", "role" },
                CreatedAt = DateTime.UtcNow.AddMonths(-4)
            },
            new ApiResource
            {
                Id = "api-2",
                Name = "payments-api",
                DisplayName = "Payments API",
                Description = "API for processing payments and managing payment methods",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "payments.read", "payments.process" },
                UserClaims = new List<string> { "sub", "email" },
                CreatedAt = DateTime.UtcNow.AddMonths(-3)
            },
            new ApiResource
            {
                Id = "api-3",
                Name = "users-api",
                DisplayName = "Users API",
                Description = "API for user management and administration",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "users.read", "users.manage" },
                UserClaims = new List<string> { "sub", "name", "email", "role" },
                CreatedAt = DateTime.UtcNow.AddMonths(-5)
            },
            new ApiResource
            {
                Id = "api-4",
                Name = "products-api",
                DisplayName = "Products API",
                Description = "API for product catalog and inventory management",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "products.read", "products.write" },
                UserClaims = new List<string> { "sub", "name", "role" },
                CreatedAt = DateTime.UtcNow.AddMonths(-2)
            },
            new ApiResource
            {
                Id = "api-5",
                Name = "inventory-api",
                DisplayName = "Inventory API",
                Description = "API for inventory tracking and warehouse management",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "inventory.read", "inventory.update" },
                UserClaims = new List<string> { "sub", "role" },
                CreatedAt = DateTime.UtcNow.AddMonths(-3)
            },
            new ApiResource
            {
                Id = "api-6",
                Name = "analytics-api",
                DisplayName = "Analytics API",
                Description = "API for business analytics and reporting",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "analytics.read" },
                UserClaims = new List<string> { "sub", "name", "role" },
                CreatedAt = DateTime.UtcNow.AddMonths(-1)
            },
            new ApiResource
            {
                Id = "api-7",
                Name = "notifications-api",
                DisplayName = "Notifications API",
                Description = "API for managing notifications and alerts",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "notifications.read", "notifications.send" },
                UserClaims = new List<string> { "sub", "email" },
                CreatedAt = DateTime.UtcNow.AddDays(-45)
            },
            new ApiResource
            {
                Id = "api-8",
                Name = "reports-api",
                DisplayName = "Reports API",
                Description = "API for generating and managing reports",
                Enabled = true,
                ShowInDiscoveryDocument = true,
                Scopes = new List<string> { "reports.read", "reports.generate" },
                UserClaims = new List<string> { "sub", "name", "role" },
                CreatedAt = DateTime.UtcNow.AddDays(-60)
            }
        };
    }

    private void InitializeScopes()
    {
        Scopes = new List<Scope>
        {
            // Identity scopes
            new Scope { Name = "openid", DisplayName = "OpenID", Description = "OpenID Connect scope", Type = "IdentityScope", Required = true, Enabled = true },
            new Scope { Name = "profile", DisplayName = "Profile", Description = "User profile information", Type = "IdentityScope", Enabled = true },
            new Scope { Name = "email", DisplayName = "Email", Description = "Email address", Type = "IdentityScope", Emphasize = true, Enabled = true },
            new Scope { Name = "phone", DisplayName = "Phone", Description = "Phone number", Type = "IdentityScope", Enabled = true },
            new Scope { Name = "address", DisplayName = "Address", Description = "Postal address", Type = "IdentityScope", Enabled = true },

            // API scopes - Orders
            new Scope { Name = "orders.read", DisplayName = "Read Orders", Description = "View order information", Type = "ApiScope", ApiResourceId = "api-1", ApiResourceName = "Orders API", Enabled = true },
            new Scope { Name = "orders.write", DisplayName = "Write Orders", Description = "Create and update orders", Type = "ApiScope", ApiResourceId = "api-1", ApiResourceName = "Orders API", Enabled = true },
            new Scope { Name = "orders.delete", DisplayName = "Delete Orders", Description = "Delete orders", Type = "ApiScope", ApiResourceId = "api-1", ApiResourceName = "Orders API", Enabled = true },

            // API scopes - Payments
            new Scope { Name = "payments.read", DisplayName = "Read Payments", Description = "View payment information", Type = "ApiScope", ApiResourceId = "api-2", ApiResourceName = "Payments API", Enabled = true },
            new Scope { Name = "payments.process", DisplayName = "Process Payments", Description = "Process payment transactions", Type = "ApiScope", ApiResourceId = "api-2", ApiResourceName = "Payments API", Enabled = true, Emphasize = true },

            // API scopes - Users
            new Scope { Name = "users.read", DisplayName = "Read Users", Description = "View user information", Type = "ApiScope", ApiResourceId = "api-3", ApiResourceName = "Users API", Enabled = true },
            new Scope { Name = "users.manage", DisplayName = "Manage Users", Description = "Create, update, and delete users", Type = "ApiScope", ApiResourceId = "api-3", ApiResourceName = "Users API", Enabled = true },

            // API scopes - Products
            new Scope { Name = "products.read", DisplayName = "Read Products", Description = "View product catalog", Type = "ApiScope", ApiResourceId = "api-4", ApiResourceName = "Products API", Enabled = true },
            new Scope { Name = "products.write", DisplayName = "Write Products", Description = "Create and update products", Type = "ApiScope", ApiResourceId = "api-4", ApiResourceName = "Products API", Enabled = true },

            // API scopes - Inventory
            new Scope { Name = "inventory.read", DisplayName = "Read Inventory", Description = "View inventory levels", Type = "ApiScope", ApiResourceId = "api-5", ApiResourceName = "Inventory API", Enabled = true },
            new Scope { Name = "inventory.update", DisplayName = "Update Inventory", Description = "Update inventory levels", Type = "ApiScope", ApiResourceId = "api-5", ApiResourceName = "Inventory API", Enabled = true },

            // API scopes - Analytics
            new Scope { Name = "analytics.read", DisplayName = "Read Analytics", Description = "View analytics data", Type = "ApiScope", ApiResourceId = "api-6", ApiResourceName = "Analytics API", Enabled = true },

            // API scopes - Notifications
            new Scope { Name = "notifications.read", DisplayName = "Read Notifications", Description = "View notifications", Type = "ApiScope", ApiResourceId = "api-7", ApiResourceName = "Notifications API", Enabled = true },
            new Scope { Name = "notifications.send", DisplayName = "Send Notifications", Description = "Send notifications", Type = "ApiScope", ApiResourceId = "api-7", ApiResourceName = "Notifications API", Enabled = true },

            // API scopes - Reports
            new Scope { Name = "reports.read", DisplayName = "Read Reports", Description = "View reports", Type = "ApiScope", ApiResourceId = "api-8", ApiResourceName = "Reports API", Enabled = true },
            new Scope { Name = "reports.generate", DisplayName = "Generate Reports", Description = "Generate new reports", Type = "ApiScope", ApiResourceId = "api-8", ApiResourceName = "Reports API", Enabled = true }
        };
    }

    private void InitializeClients()
    {
        Clients = new List<Client>
        {
            new Client
            {
                Id = "client-1",
                ClientId = "mobile-app-ios",
                ClientName = "Mobile App (iOS)",
                Description = "Native iOS mobile application for customers",
                ClientType = "Native",
                Enabled = true,
                RequireClientSecret = false,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AccessTokenLifetime = 3600,
                RefreshTokenLifetime = 2592000,
                AllowedScopes = new List<string> { "openid", "profile", "email", "orders.read", "orders.write", "products.read" },
                RedirectUris = new List<string> { "com.company.mobileapp://callback", "com.company.mobileapp://oauth2redirect" },
                PostLogoutRedirectUris = new List<string> { "com.company.mobileapp://logout" },
                AllowedGrantTypes = new List<string> { "authorization_code", "refresh_token" },
                CreatedAt = DateTime.UtcNow.AddMonths(-5),
                LastUsed = DateTime.UtcNow.AddHours(-3),
                TotalRequests = 45230
            },
            new Client
            {
                Id = "client-2",
                ClientId = "web-portal",
                ClientName = "Web Portal",
                Description = "Main web application portal for enterprise customers",
                ClientType = "Web",
                Enabled = true,
                RequireClientSecret = true,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AccessTokenLifetime = 3600,
                RefreshTokenLifetime = 2592000,
                AllowedScopes = new List<string> { "openid", "profile", "email", "phone", "orders.read", "orders.write", "payments.read", "products.read", "analytics.read" },
                RedirectUris = new List<string> { "https://portal.company.com/signin-oidc", "https://portal.company.com/callback" },
                PostLogoutRedirectUris = new List<string> { "https://portal.company.com/signout-callback" },
                AllowedCorsOrigins = new List<string> { "https://portal.company.com" },
                AllowedGrantTypes = new List<string> { "authorization_code", "refresh_token" },
                ClientSecrets = new List<ClientSecret>
                {
                    new ClientSecret { Value = "secret_abc123xyz789def456", CreatedAt = DateTime.UtcNow.AddMonths(-5) }
                },
                CreatedAt = DateTime.UtcNow.AddMonths(-6),
                LastUsed = DateTime.UtcNow.AddMinutes(-15),
                TotalRequests = 128450
            },
            new Client
            {
                Id = "client-3",
                ClientId = "admin-dashboard-spa",
                ClientName = "Admin Dashboard",
                Description = "Single page application for administrators",
                ClientType = "SPA",
                Enabled = true,
                RequireClientSecret = false,
                RequirePkce = true,
                AllowOfflineAccess = false,
                AccessTokenLifetime = 1800,
                AllowedScopes = new List<string> { "openid", "profile", "email", "users.read", "users.manage", "orders.read", "payments.read", "analytics.read" },
                RedirectUris = new List<string> { "https://admin.company.com/callback", "http://localhost:4200/callback" },
                PostLogoutRedirectUris = new List<string> { "https://admin.company.com/", "http://localhost:4200/" },
                AllowedCorsOrigins = new List<string> { "https://admin.company.com", "http://localhost:4200" },
                AllowedGrantTypes = new List<string> { "authorization_code" },
                CreatedAt = DateTime.UtcNow.AddMonths(-4),
                LastUsed = DateTime.UtcNow.AddHours(-1),
                TotalRequests = 32100
            },
            new Client
            {
                Id = "client-4",
                ClientId = "integration-service",
                ClientName = "Integration Service",
                Description = "Machine-to-machine service for backend integrations",
                ClientType = "Machine",
                Enabled = true,
                RequireClientSecret = true,
                AllowOfflineAccess = false,
                AccessTokenLifetime = 3600,
                AllowedScopes = new List<string> { "orders.read", "orders.write", "products.read", "inventory.read", "inventory.update" },
                AllowedGrantTypes = new List<string> { "client_credentials" },
                ClientSecrets = new List<ClientSecret>
                {
                    new ClientSecret { Value = "secret_m2m_service_key_xyz", CreatedAt = DateTime.UtcNow.AddMonths(-3) }
                },
                CreatedAt = DateTime.UtcNow.AddMonths(-3),
                LastUsed = DateTime.UtcNow.AddMinutes(-5),
                TotalRequests = 215670
            },
            new Client
            {
                Id = "client-5",
                ClientId = "partner-api-client",
                ClientName = "Partner API Client",
                Description = "API client for external partner integrations",
                ClientType = "Web",
                Enabled = true,
                RequireClientSecret = true,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AccessTokenLifetime = 3600,
                RefreshTokenLifetime = 2592000,
                AllowedScopes = new List<string> { "openid", "profile", "products.read", "orders.read" },
                RedirectUris = new List<string> { "https://partner.external.com/oauth/callback" },
                PostLogoutRedirectUris = new List<string> { "https://partner.external.com/logout" },
                AllowedCorsOrigins = new List<string> { "https://partner.external.com" },
                AllowedGrantTypes = new List<string> { "authorization_code", "refresh_token" },
                ClientSecrets = new List<ClientSecret>
                {
                    new ClientSecret { Value = "secret_partner_key_123abc", CreatedAt = DateTime.UtcNow.AddMonths(-2) }
                },
                CreatedAt = DateTime.UtcNow.AddMonths(-2),
                LastUsed = DateTime.UtcNow.AddHours(-12),
                TotalRequests = 15890
            },
            new Client
            {
                Id = "client-6",
                ClientId = "mobile-app-android",
                ClientName = "Mobile App (Android)",
                Description = "Native Android mobile application",
                ClientType = "Native",
                Enabled = true,
                RequireClientSecret = false,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AccessTokenLifetime = 3600,
                RefreshTokenLifetime = 2592000,
                AllowedScopes = new List<string> { "openid", "profile", "email", "orders.read", "orders.write", "products.read", "notifications.read" },
                RedirectUris = new List<string> { "com.company.android://callback" },
                PostLogoutRedirectUris = new List<string> { "com.company.android://logout" },
                AllowedGrantTypes = new List<string> { "authorization_code", "refresh_token" },
                CreatedAt = DateTime.UtcNow.AddMonths(-5),
                LastUsed = DateTime.UtcNow.AddHours(-2),
                TotalRequests = 52340
            },
            new Client
            {
                Id = "client-7",
                ClientId = "reporting-service",
                ClientName = "Reporting Service",
                Description = "Automated reporting and analytics service",
                ClientType = "Machine",
                Enabled = true,
                RequireClientSecret = true,
                AllowOfflineAccess = false,
                AccessTokenLifetime = 7200,
                AllowedScopes = new List<string> { "orders.read", "analytics.read", "reports.read", "reports.generate" },
                AllowedGrantTypes = new List<string> { "client_credentials" },
                ClientSecrets = new List<ClientSecret>
                {
                    new ClientSecret { Value = "secret_reporting_service_xyz", CreatedAt = DateTime.UtcNow.AddMonths(-1) }
                },
                CreatedAt = DateTime.UtcNow.AddMonths(-1),
                LastUsed = DateTime.UtcNow.AddHours(-6),
                TotalRequests = 8920
            },
            new Client
            {
                Id = "client-8",
                ClientId = "customer-portal-spa",
                ClientName = "Customer Portal SPA",
                Description = "Customer-facing single page application",
                ClientType = "SPA",
                Enabled = true,
                RequireClientSecret = false,
                RequirePkce = true,
                AllowOfflineAccess = false,
                AccessTokenLifetime = 3600,
                AllowedScopes = new List<string> { "openid", "profile", "email", "orders.read", "products.read" },
                RedirectUris = new List<string> { "https://customers.company.com/auth/callback", "http://localhost:3000/auth/callback" },
                PostLogoutRedirectUris = new List<string> { "https://customers.company.com/", "http://localhost:3000/" },
                AllowedCorsOrigins = new List<string> { "https://customers.company.com", "http://localhost:3000" },
                AllowedGrantTypes = new List<string> { "authorization_code" },
                CreatedAt = DateTime.UtcNow.AddDays(-45),
                LastUsed = DateTime.UtcNow.AddMinutes(-30),
                TotalRequests = 67200
            }
        };
    }

    private void InitializeAuditLogs()
    {
        var random = new Random();
        var eventTypes = new[] { "User Login", "User Logout", "User Created", "User Updated", "User Deleted", "Password Changed", "Password Reset", "Role Assigned", "Role Removed", "Client Created", "Client Updated", "Client Deleted", "API Resource Created", "API Resource Updated", "Scope Modified", "MFA Enabled", "MFA Disabled", "Session Revoked", "Permission Changed", "Configuration Updated", "Failed Login", "Account Locked" };
        var results = new[] { "Success", "Success", "Success", "Success", "Success", "Success", "Success", "Failure" };

        AuditLogs = new List<AuditLog>();

        for (int i = 1; i <= 150; i++)
        {
            var user = Users[random.Next(Users.Count)];
            var eventType = eventTypes[random.Next(eventTypes.Length)];
            var result = eventType == "Failed Login" || eventType == "Account Locked" ? "Failure" : results[random.Next(results.Length)];

            AuditLogs.Add(new AuditLog
            {
                Id = $"log-{i}",
                Timestamp = DateTime.UtcNow.AddHours(-random.Next(1, 720)),
                EventType = eventType,
                UserId = user.Id,
                Username = user.Username,
                UserEmail = user.Email,
                Action = eventType,
                Resource = eventType.Contains("Client") ? "Client" : eventType.Contains("Role") ? "Role" : eventType.Contains("User") ? "User" : "System",
                ResourceId = $"resource-{random.Next(1, 100)}",
                IpAddress = $"{random.Next(10, 192)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(1, 255)}",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
                Result = result,
                Details = $"{eventType} performed by {user.Username}"
            });
        }

        AuditLogs = AuditLogs.OrderByDescending(x => x.Timestamp).ToList();
    }

    private void InitializeUserSessions()
    {
        var random = new Random();
        var devices = new[] { "Windows Desktop", "MacBook Pro", "iPhone 13", "iPad Pro", "Samsung Galaxy", "Linux Workstation", "Windows Laptop" };
        var browsers = new[] { "Chrome 118", "Firefox 119", "Safari 17", "Edge 118", "Opera 104" };
        var locations = new[] { "New York, NY", "Los Angeles, CA", "Chicago, IL", "San Francisco, CA", "Seattle, WA", "Austin, TX", "Boston, MA" };

        UserSessions = new List<UserSession>();

        // Create sessions for first 20 users
        for (int i = 1; i <= 20; i++)
        {
            var user = Users[i - 1];
            var sessionCount = random.Next(1, 4);

            for (int j = 0; j < sessionCount; j++)
            {
                UserSessions.Add(new UserSession
                {
                    Id = $"session-{i}-{j}",
                    UserId = user.Id,
                    Device = devices[random.Next(devices.Length)],
                    Browser = browsers[random.Next(browsers.Length)],
                    Location = locations[random.Next(locations.Length)],
                    IpAddress = $"{random.Next(10, 192)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(1, 255)}",
                    CreatedAt = DateTime.UtcNow.AddHours(-random.Next(1, 168)),
                    LastActive = DateTime.UtcNow.AddMinutes(-random.Next(1, 120)),
                    IsCurrent = j == 0,
                    IsTrusted = random.Next(0, 10) > 6
                });
            }
        }
    }

    private void InitializeApiKeys()
    {
        var random = new Random();
        var keyNames = new[] { "Production API Key", "Development API Key", "Testing Key", "Integration Key", "Mobile App Key", "Partner Integration", "Staging Environment", "CI/CD Pipeline Key" };

        ApiKeys = new List<ApiKey>();

        // Create API keys for first 10 users
        for (int i = 1; i <= 15; i++)
        {
            var user = Users[random.Next(Math.Min(20, Users.Count))];
            var status = new[] { "Active", "Active", "Active", "Expired", "Revoked" };
            var keyStatus = status[random.Next(status.Length)];

            ApiKeys.Add(new ApiKey
            {
                Id = $"apikey-{i}",
                UserId = user.Id,
                Name = keyNames[random.Next(keyNames.Length)],
                Description = "API key for accessing protected resources",
                Key = $"sk_live_{Guid.NewGuid().ToString().Replace("-", "")}",
                CreatedAt = DateTime.UtcNow.AddDays(-random.Next(1, 180)),
                ExpiresAt = keyStatus == "Expired" ? DateTime.UtcNow.AddDays(-random.Next(1, 30)) : (random.Next(0, 10) > 7 ? DateTime.UtcNow.AddDays(random.Next(30, 365)) : null),
                LastUsed = keyStatus == "Active" ? DateTime.UtcNow.AddHours(-random.Next(1, 48)) : null,
                Status = keyStatus,
                Scopes = new List<string> { "openid", "profile", "api1.read", "api1.write" },
                RequestCount = keyStatus == "Active" ? random.Next(100, 10000) : 0
            });
        }
    }
}
