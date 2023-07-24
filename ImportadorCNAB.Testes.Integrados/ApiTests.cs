using ImportadorCNAB.Api.Application.Dtos;
using ImportadorCNAB.Testes.Integrados.Config;
using ImportadorCNAB.Testes.Integrados.Fixture;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ImportadorCNAB.Testes.Integrados;

[TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")]
[Collection(nameof(IntegrationApiTestsFixtureCollection))]
public class ApiTests
{
    private readonly IntegrationTestsFixture<Program> _testsFixture;

    public ApiTests(IntegrationTestsFixture<Program> testsFixture)
    {
        _testsFixture = testsFixture;
    }

    [Fact(DisplayName = nameof(Importar_Arquivo_DeveRetornarComErro)), TestPriority(1)]
    [Trait("Integração API - Importador", "ImportadorController")]
    public async Task Importar_Arquivo_DeveRetornarComErro()
    {
        var bytes = Encoding.UTF8.GetBytes("");
        using var ms = new MemoryStream(bytes);
        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");

        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(file.OpenReadStream());
        content.Add(fileContent, "file", file.FileName);

        // Act
        var postResponse = await _testsFixture.Client.PostAsync("api/ImportadorCnab", content);

        // Assert
        Assert.False(postResponse.IsSuccessStatusCode);
    }

    [Fact(DisplayName = nameof(Importar_Arquivo_DeveRetornarComSucesso)), TestPriority(2)]
    [Trait("Integração API - Importador", "ImportadorController")]
    public async Task Importar_Arquivo_DeveRetornarComSucesso()
    {
        var bytes = Encoding.UTF8.GetBytes("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ");
        using var ms = new MemoryStream(bytes);
        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");

        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(file.OpenReadStream());
        content.Add(fileContent, "file", file.FileName);

        // Act
        var postResponse = await _testsFixture.Client.PostAsync("api/ImportadorCnab", content);

        // Assert
        Assert.True(postResponse.IsSuccessStatusCode);
    }

    [Fact(DisplayName = nameof(Importar_Arquivo_DeveRetornarComSucesso)), TestPriority(3)]
    [Trait("Integração API - Importador", "ImportadorController")]
    public async Task Obter_lojas_DeveRetornarComSucesso()
    {
        var bytes = Encoding.UTF8.GetBytes("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ");
        using var ms = new MemoryStream(bytes);
        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");

        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(file.OpenReadStream());
        content.Add(fileContent, "file", file.FileName);

        // Act
        var postResponse = await _testsFixture.Client.PostAsync("api/ImportadorCnab", content);
        var getResponse = await _testsFixture.Client.GetAsync("api/Cliente/ObterLojas");
        var objetoResponse = await _testsFixture.DeserializarObjetoResponse<List<LojaDto>>(getResponse);
        // Assert
        Assert.True(getResponse.IsSuccessStatusCode);
        Assert.NotEmpty(objetoResponse);
    }

    [Fact(DisplayName = nameof(Importar_Arquivo_DeveRetornarComSucesso)), TestPriority(4)]
    [Trait("Integração API - Importador", "ImportadorController")]
    public async Task Obter_Cliente_DeveRetornarComSucesso()
    {
        var bytes = Encoding.UTF8.GetBytes("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ");
        using var ms = new MemoryStream(bytes);
        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");

        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(file.OpenReadStream());
        content.Add(fileContent, "file", file.FileName);

        // Act
        var postResponse = await _testsFixture.Client.PostAsync("api/ImportadorCnab", content);
        var getResponseLojas = await _testsFixture.Client.GetAsync("api/Cliente/ObterLojas");
        var objetoResponse = await _testsFixture.DeserializarObjetoResponse<List<LojaDto>>(getResponseLojas);
        var id = objetoResponse.First().Id;
        var getResponseCliente = await _testsFixture.Client.GetAsync($"/api/Cliente/{id}");
        var objetoResponseCliente = await _testsFixture.DeserializarObjetoResponse<ClienteDto>(getResponseCliente);

        // Assert
        Assert.True(getResponseCliente.IsSuccessStatusCode);
        Assert.NotNull(objetoResponseCliente);
        Assert.Equal(id, objetoResponseCliente.Id);
    }

    [Fact(DisplayName = nameof(Importar_Arquivo_DeveRetornarComSucesso)), TestPriority(5)]
    [Trait("Integração API - Importador", "ImportadorController")]
    public async Task Obter_Cliente_DeveRetornarComErro_cliente_nao_encontrado()
    {
        var bytes = Encoding.UTF8.GetBytes("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ");
        using var ms = new MemoryStream(bytes);
        IFormFile file = new FormFile(ms, 0, bytes.Length, "cnab", "cnab.txt");

        using var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(file.OpenReadStream());
        content.Add(fileContent, "file", file.FileName);

        // Act
        var postResponse = await _testsFixture.Client.PostAsync("api/ImportadorCnab", content);
        var id = 0;
        var getResponseCliente = await _testsFixture.Client.GetAsync($"/api/Cliente/{id}");

        // Assert
        Assert.False(getResponseCliente.IsSuccessStatusCode);
        Assert.Equal(StatusCodes.Status404NotFound, (int)getResponseCliente.StatusCode);
    }
}