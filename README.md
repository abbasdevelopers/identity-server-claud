# Identity Server - Production-Ready GUI

A comprehensive, production-ready Identity Server web application built with **ASP.NET Core 8.0 MVC** and **Tailwind CSS**. This application provides a complete identity management solution with a polished, professional user interface.

## Features

### Authentication & Security
- **Login/Register** - Full authentication workflow with email validation
- **Multi-Factor Authentication (MFA)** - Support for authenticator apps, SMS, and email
- **Password Management** - Forgot password and reset password flows
- **Social Login** - Integration points for Google, Microsoft, and GitHub
- **Session Management** - Track and manage active user sessions
- **Security Dashboard** - Monitor account security and enable MFA

### Admin Dashboard
- **User Management** - Complete CRUD operations for users
  - List, create, edit, and delete users
  - Assign roles and permissions
  - Lock/unlock accounts
  - Reset passwords
  - View user activity and sessions
- **Role Management** - Define and manage user roles with granular permissions
- **Client Applications** - Manage OAuth 2.0 / OpenID Connect clients
  - Web applications
  - Single Page Applications (SPAs)
  - Native/Mobile apps
  - Machine-to-Machine (M2M) services
- **API Resources** - Configure protected API resources with scopes
- **Identity Resources** - Manage identity claims (profile, email, phone, etc.)
- **Scopes Management** - Define and assign OAuth scopes
- **Audit Logs** - Comprehensive activity logging with advanced filtering
- **Analytics Dashboard** - Visual insights into system usage
- **System Configuration** - Centralized configuration management

### User Dashboard
- **Profile Management** - Update personal information and preferences
- **Security Settings** - Manage passwords, 2FA, and trusted devices
- **Connected Accounts** - Link/unlink social accounts
- **API Keys** - Generate and manage API keys for integrations
- **Activity Timeline** - View account activity history

## Technology Stack

- **Backend**: ASP.NET Core 8.0 MVC
- **Styling**: Tailwind CSS 3.x (via CDN)
- **JavaScript**: Vanilla JS for interactivity
- **Icons**: Heroicons (inline SVG)
- **Mock Data**: In-memory data with 60+ sample users, 8+ clients, 8 API resources, etc.

## Project Structure

```
IdentityServer/
├── Controllers/
│   ├── AccountController.cs        # Authentication flows
│   ├── AdminController.cs          # Admin dashboard
│   ├── DashboardController.cs      # User dashboard
│   ├── HomeController.cs           # Home/landing pages
│   └── UsersController.cs          # User profile management
├── Models/
│   ├── User.cs                     # User entity
│   ├── Client.cs                   # OAuth client
│   ├── Role.cs                     # User role
│   ├── ApiResource.cs              # API resource
│   ├── IdentityResource.cs         # Identity resource
│   ├── Scope.cs                    # OAuth scope
│   ├── AuditLog.cs                 # Audit log entry
│   ├── UserSession.cs              # User session
│   ├── ApiKey.cs                   # API key
│   └── ViewModels/                 # View models for forms
├── Services/
│   └── MockDataService.cs          # Mock data provider
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml          # Main layout
│   │   ├── _AdminLayout.cshtml     # Admin layout
│   │   └── _LoginLayout.cshtml     # Auth pages layout
│   ├── Account/                    # Authentication views
│   ├── Admin/                      # Admin views
│   ├── Dashboard/                  # User dashboard views
│   └── Users/                      # User profile views
├── wwwroot/
│   ├── css/
│   │   └── site.css                # Custom styles
│   └── js/
│       └── site.js                 # Interactive JavaScript
├── Program.cs                      # Application entry point
└── IdentityServer.csproj           # Project file
```

## Getting Started

### Prerequisites

- **.NET 8.0 SDK** or later
- Any modern web browser

### Installation & Running

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd identity-server-claud
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Open your browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### Default Routes

- **Login**: `/Account/Login`
- **Register**: `/Account/Register`
- **User Dashboard**: `/Dashboard`
- **Admin Dashboard**: `/Admin`
- **User Management**: `/Admin/Users`

## Mock Data

The application includes comprehensive mock data:

- **60 Users** with diverse profiles, roles, and statuses
- **8 Client Applications** (Web, SPA, Native, M2M)
- **8 API Resources** with associated scopes
- **6 Identity Resources** (openid, profile, email, phone, address, roles)
- **20+ Scopes** for fine-grained permissions
- **8 Roles** with permission sets
- **150 Audit Log Entries** for activity tracking
- **40+ User Sessions** across multiple devices
- **15 API Keys** with various statuses

## UI Features

### Responsive Design
- Mobile-first approach
- Collapsible sidebar on mobile
- Touch-friendly controls
- Adaptive layouts for all screen sizes

### Interactive Components
- **Dropdowns** - User menus, filters, bulk actions
- **Modals** - Confirmations, forms, details
- **Tabs** - Organize content in admin pages
- **Toast Notifications** - Success/error messages
- **Password Strength Meter** - Real-time validation
- **Copy to Clipboard** - For API keys, client IDs, etc.
- **Form Validation** - Client-side validation
- **Tooltips** - Contextual help

### Accessibility
- Semantic HTML
- ARIA labels
- Keyboard navigation support
- Focus indicators
- High contrast color scheme

## Page Highlights

### Login Page
- Email/password authentication
- Remember me option
- Password visibility toggle
- Social login buttons (Google, Microsoft, GitHub)
- Forgot password link
- Sign up link

### Admin Dashboard
- 6 KPI stat cards (Total Users, Active Sessions, Total Clients, Failed Logins, etc.)
- Login trends chart (7-day bar chart)
- Users by role distribution
- Recent activity feed
- System alerts panel
- Quick action cards

### User Management
- Advanced filtering (search, role, status)
- Bulk actions (activate, deactivate, delete, export)
- User table with avatars, roles, status badges
- Pagination controls
- Per-user action menu (view, edit, reset password, lock/unlock, delete)
- Verified badge for confirmed emails

### User Dashboard
- Welcome banner with personalized greeting
- 4 stat cards (Active Sessions, API Keys, Security Score, Last Login)
- Quick action cards (Update Profile, Enable MFA, Generate API Key)
- Recent activity timeline
- Real-time data from mock service

## Customization

### Changing Colors
Edit `wwwroot/css/site.css` to customize the color scheme. Tailwind classes can be modified throughout the views.

### Adding Real Data
Replace `MockDataService` with actual database services. Implement repository pattern and connect to your database (SQL Server, PostgreSQL, etc.).

### Authentication
Integrate with ASP.NET Core Identity or IdentityServer4/Duende IdentityServer for real authentication.

## Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## License

This project is provided as-is for demonstration and educational purposes.

## Screenshots

The application includes:
- Modern, clean design with Tailwind CSS
- Gradient accents and shadows
- Professional typography
- Intuitive navigation
- Consistent spacing and alignment
- Polished hover states and transitions

## Future Enhancements

Potential areas for expansion:
- Real database integration (Entity Framework Core)
- Actual OAuth 2.0 / OpenID Connect implementation
- Email service integration
- SMS service for MFA
- Advanced analytics with charts library (Chart.js, ApexCharts)
- Export functionality (CSV, Excel, PDF)
- Dark mode support
- Localization/internationalization
- Advanced search with Elasticsearch
- Rate limiting
- WebSocket for real-time notifications

## Contributing

This is a demonstration project. Feel free to fork and modify for your needs.

## Support

For issues or questions, please open an issue in the repository.

---

Built with ASP.NET Core 8.0 MVC and Tailwind CSS
