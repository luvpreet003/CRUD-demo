This project contains CRUD operations for basic school and student model implemented using EF in CQRS method and authentication and authorization applied to it using JWT token. Below are auth steps

Authentication and Authorization Implementation Guide
Authentication Setup
Install Required Packages

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
Configure JWT Settings

Add JWT configuration to appsettings.json
Define key, issuer, audience, and token expiry time
Create Authentication Models

LoginRequest, SignUpRequest, AuthResponse classes
Implement JwtService

Create service for generating JWT tokens
Include user ID, username, and role in token claims
Configure Authentication in Program.cs

Add JWT Bearer authentication
Configure token validation parameters
Add authentication and authorization middleware
Configure Swagger

Add security definition for JWT Bearer tokens
Add security requirement to display lock icon
Create Auth Controller

Implement Login and Register endpoints
Add password hashing methods
Return JWT tokens upon successful authentication
Role-Based Authorization
Add Role to User Model

Add Role property to UsersDTO class
Create migration to add Role column
Update JwtService

Include user role in token claims
Configure Role-Based Authorization

Set up authorization policies in Program.cs
Use the ClaimTypes.Role for role claim type
Apply Authorization Attributes

Use [Authorize] to require authentication
Use [Authorize(Roles = "Admin")] for role-specific access
Use [Authorize(Policy = "PolicyName")] for policy-based access
Customize Forbidden Responses

Configure custom 403 Forbidden responses
Return appropriate error messages
Testing
Register a user account
Login and get JWT token
Include token in Authorization header: Bearer your_token_here
Test access to protected endpoints
Common Status Codes
200 OK: Successful request
401 Unauthorized: Missing or invalid token
403 Forbidden: Valid token but insufficient permissions
404 Not Found: Resource doesn't exist
500 Server Error: Server-side exception
Security Best Practices
Use HTTPS in production
Store secure JWT key in environment variables
Use proper password hashing (e.g., BCrypt)
Implement token refresh mechanism
Set appropriate token expiration time
Validate all user inputs
Don't expose sensitive information in responses
