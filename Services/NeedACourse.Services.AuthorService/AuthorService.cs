namespace NeedACourse.Services.AuthorService;

using AutoMapper;
using NeedACourse.Db.Context;
using Microsoft.EntityFrameworkCore;
using NeedACourse.Services.AuthorService.Models;

public class AuthorService : IAuthorService
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;

    public AuthorService(
        IDbContextFactory<MainDbContext> contextFactory, 
        IMapper mapper
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
    }

    public async Task<AuthorModel> GetAuthorById(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var author = context.Authors.First(x => x.Id == id);
        var authorModel = mapper.Map<AuthorModel>(author);
        return authorModel;
    }

    public async Task<IEnumerable<AuthorModel>> GetAuthors()
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var Authors = context
            .Authors
            .AsQueryable();

        var data = (await Authors.ToListAsync()).Select(Author => mapper.Map<AuthorModel>(Author));

        return data;
    }
}
