using System.Net;
using System.Threading.Tasks;
using Learning.Shop.API.Catalog.Contract.Query;
using Learning.Shop.API.Catalog.Contract.Response;
using Learning.Shop.API.Catalog.Services.Abstract.Interfaces.Search;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Shop.API.Catalog.Controllers
{
    [ApiController]
    [Route("catalog/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(SearchResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Search(CatalogSearchQuery query)
            => query == null
                ? (IActionResult)BadRequest()
                : Ok(await _searchService.Search(
                    query.SearchTerm,
                    query.PageSize,
                    query.PageNumber));
    }
}
