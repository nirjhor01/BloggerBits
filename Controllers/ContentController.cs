using BloggerBits.Models.Request;
using BloggerBits.Services.Contents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerBits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContenService _contenService;
        public ContentController(IContenService contenService)
        {
            _contenService = contenService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> addContent( ContentRequest contentRequest)
        {
            
            var content = await _contenService.AddAsync(contentRequest);
            return Ok(content);

        }


    }
}
