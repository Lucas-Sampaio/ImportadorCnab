using ImportadorCNAB.Testes.Integrados.Config;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace ImportadorCNAB.Testes.Integrados.Fixture;

[CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Program>>
{ }

public class IntegrationTestsFixture<TProgram> : IDisposable where TProgram : class
{
    public readonly ApiFactory<TProgram> Factory;
    public HttpClient Client;

    public IntegrationTestsFixture()
    {
        var clientOptions = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            //BaseAddress = new Uri("http://localhost"),
            HandleCookies = true,
            MaxAutomaticRedirections = 7
        };
        Factory = new ApiFactory<TProgram>();
        Client = Factory.CreateClient(clientOptions);
    }

    public async ValueTask<T> DeserializarObjetoResponse<T>(HttpResponseMessage response)
    {
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
    }
    public void Dispose()
    {
        Client.Dispose();
        Factory.Dispose();
    }
}