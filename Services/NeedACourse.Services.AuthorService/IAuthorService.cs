using NeedACourse.Services.AuthorService.Models;

namespace NeedACourse.Services.AuthorService;

public interface IAuthorService
{
    Task<IEnumerable<AuthorModel>> GetAuthors();
    Task<AuthorModel> GetAuthorById(int id);
}
