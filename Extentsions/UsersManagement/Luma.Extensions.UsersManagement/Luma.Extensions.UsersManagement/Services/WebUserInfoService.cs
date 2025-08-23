using Luma.Extensions.UsersManagement.Abstractions;
using Luma.Extensions.UsersManagement.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Luma.Extensions.UsersManagement.Extensions;

namespace Luma.Extensions.UsersManagement.Services;
public class WebUserInfoService(IHttpContextAccessor httpContextAccessor, IOptions<UserManagementOptions> configuration) : IUserInfoService
{
    private readonly UserManagementOptions _configuration = configuration.Value;

    public string GetUserAgent()
        => httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"] ?? _configuration.DefaultUserAgent;

    public string GetUserIp()
        => httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? _configuration.DefaultUserIp;

    public string UserId()
        => httpContextAccessor?.HttpContext?.User?.GetClaim(ClaimTypes.NameIdentifier) ?? string.Empty;

    public string GetUsername()
        => httpContextAccessor.HttpContext?.User?.GetClaim(ClaimTypes.Name) ?? _configuration.DefaultUsername;

    public string GetFirstName()
        => httpContextAccessor.HttpContext?.User?.GetClaim(ClaimTypes.GivenName) ?? _configuration.DefaultFirstName;

    public string GetLastName()
        => httpContextAccessor.HttpContext?.User?.GetClaim(ClaimTypes.Surname) ?? _configuration.DefaultLastName;

    public bool IsCurrentUser(string userId)
        => string.Equals(UserId(), userId, StringComparison.OrdinalIgnoreCase);

    public string? GetClaim(string claimType)
        => httpContextAccessor.HttpContext?.User?.GetClaim(claimType);

    public string UserIdOrDefault() => UserIdOrDefault(_configuration.DefaultUserId);

    public string UserIdOrDefault(string defaultValue)
    {
        string userId = UserId();
        return string.IsNullOrEmpty(userId) ? defaultValue : userId;
    }

    // New methods for custom claims
    public string GetMobile()
        => GetClaimOrDefault("mobile", _configuration.DefaultMobile);

    public string GetEmail()
        => GetClaimOrDefault("email", _configuration.DefaultEmail);

    public string GetFullName()
        => GetClaimOrDefault("fullname", _configuration.DefaultFullName);

    private string GetClaimOrDefault(string claimType, string defaultValue)
        => httpContextAccessor.HttpContext?.User?.GetClaim(claimType) ?? defaultValue;
}

