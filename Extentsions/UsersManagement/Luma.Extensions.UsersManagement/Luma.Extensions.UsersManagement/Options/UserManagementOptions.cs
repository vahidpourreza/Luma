namespace Luma.Extensions.UsersManagement.Options;

public sealed class UserManagementOptions
{
    public string DefaultUserId { get; set; } = "1";
    public string DefaultUserAgent { get; set; } = "Unknown";
    public string DefaultUserIp { get; set; } = "0.0.0.0";
    public string DefaultUsername { get; set; } = "UnknownUserName";
    public string DefaultFirstName { get; set; } = "UnknownFirstName";
    public string DefaultLastName { get; set; } = "UnknownLastName";

    // Defaults for new custom claims
    public string DefaultMobile { get; set; } = "UnknownMobile";
    public string DefaultEmail { get; set; } = "UnknownEmail";
    public string DefaultFullName { get; set; } = "UnknownFullName";
}

