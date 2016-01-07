using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Crap.Data.Entities;
using Crap.Data.Providers;
using Crap.UI.ViewModels;

namespace Crap.UI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseApiController
    {
        private readonly IRepository<Category> _categoryRepository; 
        public CategoriesController(IRepository<Error> errorRepository, IRepository<Category> categoryRepository) : base(errorRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var categories = _categoryRepository.ToList();
                var categoriesVm = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
                var response = request.CreateResponse(HttpStatusCode.OK, categoriesVm);
                return response;
            });
        }
    }
}