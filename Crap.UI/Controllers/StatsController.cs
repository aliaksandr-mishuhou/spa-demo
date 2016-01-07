using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Crap.Data.Entities;
using Crap.Data.Providers;
using Crap.UI.ViewModels;

namespace Crap.UI.Controllers
{
    public class StatsController : BaseApiController
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Order> _orderRepository; 

        public StatsController(IRepository<Error> errorRepository,
            IRepository<Category> categoryRepository,
            IRepository<Product> productRepository,
            IRepository<Order> orderRepository) 
            : base(errorRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public HttpResponseMessage Summary(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var summary = new SummaryViewModel
                {
                    TotalCategories = _categoryRepository.Count(),
                    TotalProducts = _productRepository.Count(),
                    TotalOrders = _orderRepository.Count()
                };
                var response = request.CreateResponse(HttpStatusCode.OK, summary);
                return response;
            });
        }
    }
}