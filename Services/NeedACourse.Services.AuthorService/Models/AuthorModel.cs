using AutoMapper;
using NeedACourse.Db.Entities;

namespace NeedACourse.Services.AuthorService.Models;

public class AuthorModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class AuthorModelProfile : Profile
{
    public AuthorModelProfile()
    {
        CreateMap<Author, AuthorModel>();
    }
}