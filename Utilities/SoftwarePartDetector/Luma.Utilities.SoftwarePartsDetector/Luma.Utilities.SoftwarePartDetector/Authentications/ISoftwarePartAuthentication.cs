using IdentityModel.Client;

namespace Luma.Utilities.SoftwarePartDetector.Authentications;

public interface ISoftwarePartAuthentication
{
    Task<TokenResponse> LoginAsync();
}
