namespace Hony.Api;

public static class ExtensionBuilderServices
{
    public static IConfigurationBuilder AddEnvConfigurations(this ConfigurationManager builder)
    {
        builder.AddEnvironmentVariables("POST_CONNECTION");
        builder.AddEnvironmentVariables("MONG_CONNECTION");
        return builder;
    }
}