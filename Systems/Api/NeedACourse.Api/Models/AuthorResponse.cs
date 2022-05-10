using AutoMapper;
using NeedACourse.Services.AuthorService.Models;

namespace NeedACourse.Api.Models;
public class AuthorResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class AuthorResponseProfile : Profile
{
    public AuthorResponseProfile()
    {
        CreateMap<AuthorModel, AuthorResponse>();
    }
}