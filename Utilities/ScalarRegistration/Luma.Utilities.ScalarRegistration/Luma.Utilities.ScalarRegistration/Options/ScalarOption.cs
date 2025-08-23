namespace Luma.Utilities.ScalarRegistration.Options;

public class ScalarOption
{
    public bool Enabled { get; set; } = true;
    public string Name { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Version { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public string Layout { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public string EndpointPrefix { get; set; } = string.Empty;
    public ScalarClientCredentialsFlowOption ClientCredentials { get; set; } = new();
}

public class ScalarClientCredentialsFlowOption
{
    public bool Enabled { get; set; } = true;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public List<string>? SelectedScopes { get; set; }
}

