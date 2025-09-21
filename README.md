# TestTwo ASP.NET Core Web App

This project is an ASP.NET Core MVC web application with Microsoft account authentication (OAuth/OpenID Connect). It supports signup and sign-in with Microsoft, displays the signed-in user's name in the navbar, and provides a dropdown with profile and logout links. The app uses HTTPS on port 5004 and cookie authentication. You must provide your own Microsoft app registration, client ID, and secret.

## Getting Started

1. Configure your Microsoft app registration and update the authentication settings in `appsettings.json` or `Program.cs`.
2. Run the app with HTTPS on port 5004.
3. Sign up or sign in using your Microsoft account.

## Features
- Signup and sign-in with Microsoft account
- User name displayed in navbar
- Dropdown with profile and logout
- HTTPS (port 5004)

## Setup
- .NET 8.0 SDK or later
- Visual Studio 2022+ or VS Code

## Redirect URI
- `https://localhost:5004/signin-oidc`

---
Replace this README with more details as you customize the project.
