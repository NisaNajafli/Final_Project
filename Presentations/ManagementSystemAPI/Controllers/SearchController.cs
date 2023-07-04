using Application.DTOs.ClientDto;
using Application.DTOs.EmployeeDto;
using Application.Services.SearchService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet("Search/Employee")]
        public async Task<IActionResult> SearchEmployee( [FromQuery] string username)
        {
            try
            {
                List<GetEmployeeForSearch> searchResults = await _searchService.SearchEmployee( username);

                if (searchResults.Count > 0)
                {
                    return Ok(searchResults);
                }
                else
                {
                    return NotFound("No search results found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("Search/Client")]
        public async Task<IActionResult> SearchClient([FromQuery] string username)
        {
            try
            {
                List<GetClientForSearch> searchResults = await _searchService.SearchClient(username);

                if (searchResults.Count > 0)
                {
                    return Ok(searchResults);
                }
                else
                {
                    return NotFound("No search results found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
