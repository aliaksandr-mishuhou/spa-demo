using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Logging;
using Crap.Data.Entities;
using Crap.Data.Providers;

namespace Crap.UI.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private readonly IRepository<Error> _errorRepository;
        private readonly ILog _log = LogManager.GetLogger(string.Empty);

        protected BaseApiController(IRepository<Error> errorRepository)
        {
            _errorRepository = errorRepository;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                _log.Error(ex);
                var error = new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Time = DateTime.Now
                };

                _errorRepository.Save(error);
            }
            catch (Exception eex)
            {
                _log.Error(eex);
            }
        }


    }
}
