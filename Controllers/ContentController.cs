using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Responses.Contents;
using BloggerBits.Helper;
using BloggerBits.Services.Contents;
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

        [HttpPost]
        public async Task<IActionResult> AddContentAsync(ContentRequest contentRequest)
        {

            var res = await _contenService.AddContentAsync(contentRequest);
            if (res != null)
            {
                return Ok(ApiResponse<object>.Ok(UiMessage.DATA_SAVED, res));
            }
            return Ok(ApiResponse<object>.Fail(UiMessage.DATA_SAVED_FAILED));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetContentByIdAsync([FromRoute] int id)
        {
            var res = await _contenService.GetContentByIdAsync(id);
            if(res != null)
            {
                return Ok(ApiResponse<ContentResponse>.Ok(UiMessage.DATA_FOUND, res));
            }
            return Ok(ApiResponse<object>.Fail(UiMessage.DATA_NOT_FOUND));
        }

        
    }
}
