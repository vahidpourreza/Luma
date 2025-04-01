namespace Luma.Extensions.UsersManagement.Abstractions;

public class FakeUserInfoService : IUserInfoService
{
    private readonly string _defaultUserId;

    public FakeUserInfoService() : this("1")
    {
    }

    public FakeUserInfoService(string defaultUserId)
    {
        _defaultUserId = defaultUserId;
    }

    public string? GetClaim(string claimType)
    {
        return claimType;
    }

    public string GetFirstName()
    {
        return "FirstName";
    }

    public string GetLastName()
    {
        return "LastName";
    }

    public string GetUserAgent()
    {
        return "FakeUserAgent";
    }

    public string GetUserIp()
    {
        return "0.0.0.0";
    }

    public string GetUsername()
    {
        return "FakeUsername";
    }

    public bool IsCurrentUser(string userId)
    {
        return true;
    }

    public string UserId()
    {
        return "1";
    }

    public string UserIdOrDefault() => _defaultUserId;

    public string UserIdOrDefault(string defaultValue) => defaultValue;

    // New methods for custom claims
    public string GetMobile()
    {
        return "09112344567";
    }

    public string GetEmail()
    {
        return "fake@gmail.com";
    }

    public string GetFullName()
    {
        return "Fake Full Name";
    }


}






