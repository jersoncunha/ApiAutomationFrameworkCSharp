
using System.Net;
using NUnit.Framework;
using ApiAutomationFramework.Clients;
using ApiAutomationFramework.Models;

namespace ApiAutomationFramework.Tests;

[TestFixture]
public class PostsApiTests
{
    private ApiClient _api = null!;

    [SetUp]
    public void SetUp()
    {
        _api = new ApiClient();
    }

    [Test]
    public async Task GetPost_ExistingId_ReturnsPostAnd200()
    {
        var response = await _api.GetAsync<Post>("/posts/1");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Id, Is.EqualTo(1));
        Assert.That(response.Data.Title, Is.Not.Empty);
    }

    [Test]
    public async Task GetPosts_ReturnsNonEmptyListAnd200()
    {
        var response = await _api.GetAsync<List<Post>>("/posts");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data, Is.Not.Empty);
    }

    [Test]
    public async Task CreatePost_ReturnsCreatedAnd201()
    {
        var newPost = new Post
        {
            UserId = 1,
            Title = "Teste automatizado com C#",
            Body = "Criando uma publicação via RestSharp"
        };

        var response = await _api.PostAsync<Post, Post>(
            "/posts", newPost);

        Assert.That(response.StatusCode,
            Is.EqualTo(HttpStatusCode.Created));

        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Title, Is.EqualTo(newPost.Title));
        Assert.That(response.Data.Body, Is.EqualTo(newPost.Body));
    }

    [Test]
    public async Task UpdatePost_ReturnsUpdatedPostAnd200()
    {
        var updatedPost = new Post
        {
            UserId = 1,
            Id = 1,
            Title = "Título atualizado",
            Body = "Conteúdo atualizado"
        };

        var response = await _api.PutAsync<Post, Post>(
            "/posts/1", updatedPost);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Data, Is.Not.Null);
        Assert.That(response.Data!.Title,
            Is.EqualTo(updatedPost.Title));
    }

    [Test]
    public async Task DeletePost_Returns200()
    {
        var response = await _api.DeleteAsync("/posts/1");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
