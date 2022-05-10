using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedACourse.Api.Models;
using NeedACourse.Db.Entities;
using NeedACourse.Services.AuthorService;
using NeedACourse.Services.AuthorService.Models;

namespace NeedACourse.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> logger;
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorsController(ILogger<AuthorsController> logger, IAuthorService authorService, IMapper mapper)
        {
            this.logger = logger;
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorResponse>> GetAuthors()
        {
            var authors = await authorService.GetAuthors();
            var response = mapper.Map<IEnumerable<AuthorResponse>>(authors);
            return response;
        }
        [HttpGet("{id}")]
        public async Task<AuthorResponse> GetAuthorById([FromRoute]int id)
        {
            var author = await authorService.GetAuthorById(id);
            var response = mapper.Map<AuthorResponse>(author);
            return response;
        }
    }
}
