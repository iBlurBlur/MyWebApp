using Refit;

namespace MyWebApp.Services;

public interface IUserAPI
{
    [Get("/todos/{id}")]
    Task<User> GetUser(int id);
}

public partial class User
{
    public long UserId { get; set; }
    public long Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }
}


